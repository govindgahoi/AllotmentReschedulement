﻿
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
//using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BEL_Allotment;
using BLL_Allotment;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Spire.Email.IMap;
using Spire.Email;
using Spire.Email.Smtp;
namespace Allotment
{
    public partial class ApplicationForPIP : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        string TEFFeeStatus;
        string ServiceReqNo;
        string Status;
        string TranID;
        string TempReqNo;
        string controlid;
        string App;
        string isActive;
        GeneralMethod gm = new GeneralMethod();

        SqlConnection con;

        public string Level = "";
        public string DataManager = "";
        string DocPath = "";
        string ControlID = "";
        string UnitID = "";
        string ServiceID = "";
        string RequestID = "";
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
        string Certificate_EXP_Date_DDMMYYYY = "";
        string D1 = "", D2 = "", D3 = "", D4 = "", D5 = "", D6 = "", D7 = "";
        string firstCondition = "";
        string BY_Condtion_Function = "";
        string BY_SET_Condtion_Function = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                ServiceReqNo = Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"]));

                this.RegisterPostBackControl();

                lblPayDateD.Text = DateTime.Now.ToString("dd/MM/yyyy");
                

                if (!IsPostBack)
                {
                    CheckAcceptValue();
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

                    bindDistrict();

                    bindCompanytypeddl("NO");

                    ViewState["firstCondition"] = "List of Documents for PIP";
                    BY_SET_Condtion_Function = "List of Documents for PIP";
                    BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);

                    GetFinalView();
                    CheckNMSWPFeePaidPay();

                    niveshmitrastatusupdate1();
                    //CheckNMSWPFeePaid();
                    GetApplicantDetails(ServiceReqNo);
                    BindLandDetails();

                    view_asdf1();
                    BindMakeP();
                    if (Allotment.ActiveViewIndex <= 0)
                    {
                        Allotment.ActiveViewIndex = 0;

                    }

                }
                BindObjection();
                

            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + ex.StackTrace + "');", true);
                return;
            }

        }

        public void niveshmitrastatusupdate1()
        {

            try
            {


                fetchNMdetails();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                Status_Code = "07";


                string Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "07", "Request is Rejected by Nodal Officer", RequestID, "Rejected", "");
                if (Result == "SUCCESS")
                {

                }
                else
                {

                }



            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ViewState["firstCondition"] = "List of Documents for PIP";
            BY_SET_Condtion_Function = "List of Documents for PIP";
            BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ViewState["firstCondition"] = "List of Documents for PIP";
            BY_SET_Condtion_Function = "List of Documents for PIP";
            BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ViewState["firstCondition"] = "List of Documents for PIP";
            BY_SET_Condtion_Function = "List of Documents for PIP";
            BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);
        }
        protected void view_asdf1()
        {

            //   checklisttabs.Text = "";
            string htmldata = "";
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();




                objServiceTimelinesBEL.ServiceChecklistId = "";


                DataSet ds0 = new DataSet();
                try
                {
                    ds0 = objServiceTimelinesBLL.GetServiceChecklistsPIP_SP_BY_Condtion(objServiceTimelinesBEL);

                    if (ds0.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds0.Tables[0].Rows)
                        {

                            firstCondition = ds0.Tables[0].Rows[0]["ServiceTimeLinesCondition"].ToString();
                            // htmldata += @"<a id='KK' class='font-bold' StaticSelectedStyle-CssClass='sub_menu_active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";
                            htmldata += @"<a id='KK' class='font-bold' StaticSelectedStyle-CssClass='sub_menu_active'  href = ""javascript:__doPostBack('GetServiceChecklists_SP_BY_Condtion_Function','" + dr["ServiceTimeLinesCondition"].ToString() + @"')"" >" + dr["ServiceTimeLinesCondition"].ToString() + @"</a>";



                        }

                        Literal loLit1 = new Literal();
                        loLit1.Text = (htmldata);
                        pnlDemo.Controls.Add(loLit1);



                        ViewState["firstCondition"] = firstCondition;

                        if (string.IsNullOrEmpty(BY_SET_Condtion_Function)) { BY_SET_Condtion_Function = firstCondition; }

                        BindServiceCheckListGridViewDocument(BY_SET_Condtion_Function);




                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                }

            }
            catch { }
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
                ddlDistrict.DataValueField = "Census_District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }

        }


        public void GetServiceChecklists_SP_BY_Condtion_Function(string asdf)

        {

            hfName.Value = asdf;

            ViewState["BY_Condtion_Function"] = hfName.Value;
            BY_SET_Condtion_Function = hfName.Value;

            BindServiceCheckListGridViewDocument(hfName.Value);
        }

        public void BindServiceCheckListGridViewDocument(string condition)
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.ServiceChecklistCondition = condition;
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetAllServiceChecklistsPIP(objServiceTimelinesBEL);
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
                    this.RegisterPostBackControl();
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
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Service_Id = 0; int Service_TimeLine_ID = 0; int index = 0;
            string DocPath = "";
            try
            {
                index = Convert.ToInt32(e.CommandArgument);



                Service_Id = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceCheckLists")).Text.ToString());
                Service_TimeLine_ID = Convert.ToInt32(((Label)GridView2.Rows[index].FindControl("lblServiceTimeLines")).Text.ToString());

                string DocumentID = ((Label)GridView2.Rows[index].FindControl("DocumentID")).Text.ToString();




                int maxFileSize = 20;

                if (e.CommandName == "Upload")
                {
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fu = bts.Parent.Parent.FindControl("FileUpload4") as FileUpload;//here it is detecting file upload4 

                    if (fu.HasFile)
                    {
                        string filePath = fu.PostedFile.FileName;
                        string fleUpload = Path.GetExtension(fu.FileName.ToString());
                        string filename = Path.GetFileName(filePath);
                        string contenttype = String.Empty;
                        int fileSize = fu.PostedFile.ContentLength;
                        if (fileSize > (maxFileSize * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 20 mb');", true);

                            return;
                        }
                        switch (fleUpload)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".jpeg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                            case ".PDF":
                                contenttype = "application/pdf";
                                break;
                        }
                        if (contenttype != String.Empty)
                        {



                            Stream fs = fu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);


                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            br.Close();
                            objServiceTimelinesBEL.UserName = LblAllotteeId.Text;
                            objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                            objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                            objServiceTimelinesBEL.filename = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                            objServiceTimelinesBEL.CreatedDate = DateTime.Now;
                            objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                            objServiceTimelinesBEL.LAWDocPath = "~/PIP/" + LblAllotteeId.Text + "/" + Service_Id + "/" + filename;
                            try
                            {
                                int retVal;

                                retVal = objServiceTimelinesBLL.SavePIPServiceChecklistDocument(objServiceTimelinesBEL);


                                if (retVal > 0)
                                {

                                    string folderPath = Server.MapPath("~/PIP/" + LblAllotteeId.Text + "/" + Service_Id + "/");

                                    //Check whether Directory (Folder) exists.
                                    if (!Directory.Exists(folderPath))
                                    {
                                        //If Directory (Folder) does not exists. Create it.
                                        Directory.CreateDirectory(folderPath);
                                    }
                                    //fu.SaveAs(folderPath + Path.GetFileName(fu.FileName));
                                    File.WriteAllBytes(folderPath + filename, bytes);
                                    string message = "File  Uploaded SucessFully ";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);


                                    BindServiceCheckListGridViewDocument(ViewState["firstCondition"].ToString());

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
                        else
                        {
                            string message = "Invalid File Format.Please Upload Only pdf/Jpeg/Jpg/Png files Only";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        string message = "Please Select file Then Upload";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                if (e.CommandName == "selectDocument")
                {

                    DataSet ds = new DataSet();
                    try
                    {
                        DocPath = (string)this.GridView2.DataKeys[index]["Path"];
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(DocPath));
                        Response.WriteFile(DocPath);
                        Response.End();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Oops! error occured-v :" + ex.Message.ToString());
                    }
                }

                if (e.CommandName == "ViewDocument")
                {

                    DocPath = (string)this.GridView2.DataKeys[index]["Path"];
                    Response.Write("<script>window.open ('" + DocPath.Trim().Remove(0, 2) + "','_blank');</script>");
                    //string FilePath = Server.MapPath((DocPath));
                    //WebClient User = new WebClient();
                    //Byte[] FileBuffer = User.DownloadData(FilePath);
                    //if (FileBuffer != null)
                    //{
                    //    Response.ContentType = "application/pdf";
                    //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    //    Response.BinaryWrite(FileBuffer);
                    //}
                }

            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured-v :" + ex.Message.ToString());
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LoginInfo _objLoginInfo = (LoginInfo)Session["objLoginInfo"];

                    objServiceTimelinesBEL.UserName = LblAllotteeId.Text.Trim();


                    int Service_Id = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceCheckLists")).Text.ToString());
                    int Service_TimeLine_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblServiceTimeLines")).Text.ToString());
                    string DocumentID = ((Label)e.Row.FindControl("DocumentID")).Text.ToString();



                    DataSet ds1 = new DataSet();
                    objServiceTimelinesBEL.ServiceCheckListsID = Service_Id;
                    objServiceTimelinesBEL.ServiceTimeLinesID = Service_TimeLine_ID;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.DocumentID = DocumentID;



                    ds1 = objServiceTimelinesBLL.GetPIPCheckListDocument(objServiceTimelinesBEL);
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
        private void bindCompanytypeddl(string SPV)
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                DataRow dtrownew;
                int i = 0;
                ds = objServiceTimelinesBLL.GetCompanyType();

                if (SPV == "YES")
                {
                    DataTable dttable = ds.Tables[0].Clone();
                    //loop though each row
                    foreach (DataRow dtrow in ds.Tables[0].Select("id IN (2,3,4,5)"))
                    {
                        dtrownew = dttable.NewRow();
                        //copy each field value to the new table
                        while (i < dtrow.ItemArray.Length)
                        {
                            dtrownew[i] = dtrow[i];
                            i++;
                        }
                        dttable.Rows.Add(dtrownew);
                        i = 0;
                    }
                    ddlcompanytype.DataSource = dttable;
                }
                else
                {
                    ddlcompanytype.DataSource = ds;
                }

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

        #region ShareHolderPattern
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
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Share Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide ShareHolder Name');", true);
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
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partnership Percentage');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Partner Name');", true);
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
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Trustee Name');", true);
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
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Din/Pan');", true);
                    return;
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "ShowPopup('Please Provide Director Name');", true);
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
        protected void CompanyTypeddl_selectedindex_changed(object sender, EventArgs e)
        {
            ddlcompanytype.Style.Clear();
            if (ddlcompanytype.SelectedValue == "0")
            {
                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                //   txtCompanyname.Enabled = false;
                // txtProposedPIP.Enabled = false;
            }
            else if (ddlcompanytype.SelectedValue == "1")
            {
                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
            }
            else if (ddlcompanytype.SelectedValue == "2")
            {

                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;
            }
            else if (ddlcompanytype.SelectedValue == "3")
            {
                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = true;
                tr9.Visible = false;
            }
            else if (ddlcompanytype.SelectedValue == "4")
            {
                tr2.Visible = false;
                tr4.Visible = true;
                tr8.Visible = false;
                tr9.Visible = false;

            }
            else if (ddlcompanytype.SelectedValue == "5")
            {
                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = false;
                tr9.Visible = true;
            }
            else if (ddlcompanytype.SelectedValue == "6")
            {
                tr2.Visible = false;
                tr4.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
            }

        }

        #endregion

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
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {            
            int index = Int32.Parse(e.Item.Value);

            if (index == 0)
            {
                GetApplicantDetails(ServiceReqNo);
                Allotment.ActiveViewIndex = index;
            }
            else if (index == 5)
            {
                GetFinalView();
                Allotment.ActiveViewIndex = index;
            }
            else if (index == 6)
            {
                BindObjection();
                Allotment.ActiveViewIndex = index;
            }
            else if (index == 18)
            {
                //div_final.Visible = false;
                Payment_div.Visible = true;
                BindMakeP();
                Allotment.ActiveViewIndex = 7;
            }
            else { Allotment.ActiveViewIndex = index; }




        }
        private void RegisterPostBackControl()
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveImage);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSaveSign);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnConfirm);
            foreach (GridViewRow row in GridView2.Rows)
            {

                LinkButton imgdocuments = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(imgdocuments);


                LinkButton lnkFull = row.FindControl("lbView") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull);

                LinkButton lnkFull1 = row.FindControl("lbView1") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull1);

                LinkButton lnkFull2 = row.FindControl("imgdocuments") as LinkButton;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkFull2);

            }
        }
        private void GetApplicantDetails(String ID)
        {

            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
            DataSet ds = new DataSet();
            try
            {
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                ds = objServiceTimelinesBLL.GetPIPDetails(objServiceTimelinesBEL);


                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt_project = ds.Tables[2];
                DataTable dt_serviceRequest = ds.Tables[7];

                if (dt.Rows.Count > 0)
                {
                    string AllotteeID = dt.Rows[0]["AllotteeID"].ToString();

                    string Status = dt_serviceRequest.Rows[0]["isActive"].ToString();
                    LblAllotteeId.Text = dt.Rows[0]["AllotteeID"].ToString();
                    lblApplicantName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    lblEmailID.Text = dt.Rows[0]["emailID"].ToString();
                    lblMobileNo.Text = dt.Rows[0]["PhoneNo"].ToString();

                    string Objection = dt_serviceRequest.Rows[0]["IsClarificationReq"].ToString();

                    string ApplicationSubmissionDate;
                    if (dt_serviceRequest.Rows[0]["ServiceSubmitDate"].ToString() != "")
                    {
                        ApplicationSubmissionDate = Convert.ToDateTime(dt_serviceRequest.Rows[0]["ServiceSubmitDate"].ToString()).ToShortDateString();
                    }
                    else
                    {
                        ApplicationSubmissionDate = "";
                    }

                    if (Objection == "True")
                    {
                        Allotment.ActiveViewIndex = 6;
                        
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            if (item.Text == "Final Form")
                                menuItem = item;
                        }
                        /////menuItems.Remove(menuItem);
                        
                    }
                    else
                    {
                        if (Status.Trim() == "True")
                        {
                            //div_final.Visible = false;
                            DisableAllControl();
                        }
                        else
                        {
                            //div_final.Visible = true;

                            
                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                if (item.Text == "Final Form")
                                    menuItem = item;
                                //if (item.Text == "Migration Details")
                                //    menuItem = item;
                            }
                            ////menuItems.Remove(menuItem);
                                                    }

                        //--------------------
                        /*
                        if (Convert.ToDateTime(ApplicationSubmissionDate) < Convert.ToDateTime("12/29/2022"))
                        {
                            //Allotment.ActiveViewIndex = 7;

                        }
                        else
                        {
                        
                            MenuItemCollection menuItems2 = sub_menu.Items;
                            MenuItem menuItem2 = new MenuItem();
                            foreach (MenuItem item in menuItems2)
                            {
                            // if (item.Text == "Migration Details")
                            if (item.Value == "17") { }
                                    menuItem2 = item;
                            }
                            menuItems2.Remove(menuItem2);
                        /*}*/

                            MenuItemCollection menuItems1 = sub_menu.Items;
                        MenuItem menuItem1 = new MenuItem();
                        //MenuItem mnu = sub_menu.FindItem("Migration Details");
                        //sub_menu.Items.Remove(mnu);
                        foreach (MenuItem item in menuItems1)
                        {
                            if (item.Value == "6")
                            {
                                menuItem1 = item;
                                //menuItems1.Remove(menuItem1);
                            }
                            //if (item.Value == "17")
                            //{
                            //    menuItem1 = item;
                            //    menuItems1.Remove(menuItem1);
                            //}
                        }
                        menuItems1.Remove(menuItem1);

                        /*
                        MenuItemCollection menuItems3 = sub_menu.Items;
                        MenuItem menuItem3 = new MenuItem();
                        foreach (MenuItem item in menuItems3)
                        {
                            // if (item.Text == "Migration Details")
                            if (item.Value == "7")
                                menuItem2 = item;
                        }
                        menuItems3.Remove(menuItem3);
                        */

                    }

                    if (drpSPV.SelectedValue == null)
                    {
                        drpSPV.SelectedValue = dt.Rows[0]["IsSPV"].ToString().Trim();
                        //    bindCompanytypeddl(dt.Rows[0]["IsSPV"].ToString().Trim());

                    }
                    // drpSPV.SelectedValue = dt.Rows[0]["IsSPV"].ToString().Trim();
                    bindCompanytypeddl(dt.Rows[0]["IsSPV"].ToString().Trim());


                    if (dt.Rows[0]["FirmConstitution"].ToString() == "" || dt.Rows[0]["FirmConstitution"].ToString() == null)
                    {
                        ddlcompanytype.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcompanytype.SelectedValue = dt.Rows[0]["FirmConstitution"].ToString().Trim();
                    }
                    
                    lblFormNo.Text = dt.Rows[0]["serviceReqNo"].ToString().Trim();
                    txtCompanyname.Text = dt.Rows[0]["CompanyName"].ToString().Trim();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();
                    //lblFormNo.Text = dt.Rows[0]["ApplicationID"].ToString().Trim();
                    txtGstNo.Text = dt.Rows[0]["GSTNO"].ToString().Trim();
                    txtUdyogAdhar.Text = dt.Rows[0]["UdyogAadharNo"].ToString().Trim();
                    txtApplicantAddress.Text = dt.Rows[0]["Address1"].ToString().Trim();
                    txtProjectLocation.Text = dt.Rows[0]["Address"].ToString().Trim();
                    txtApplicantAadhar.Text = dt.Rows[0]["AdharCardNo"].ToString().Trim();
                    txtFirmAddress.Text = dt.Rows[0]["CompanyAddress"].ToString().Trim();

                    txtProposedPIP.Text = dt.Rows[0]["ProposedPIP"].ToString().Trim();
                    if (dt.Rows[0]["IsRegionPIP"].ToString().Trim().Length > 0)
                    {
                        drpRegionPIP.Items.FindByText(dt.Rows[0]["IsRegionPIP"].ToString().Trim()).Selected = true;
                    }
                    


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


                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();


                    string Imagetype = dt.Rows[0]["AllotteeImageType"].ToString().Trim();
                    lblImagetype.Text = dt.Rows[0]["AllotteeImageType"].ToString().Trim();
                    lblImageName.Text = dt.Rows[0]["AllotteeImageName"].ToString().Trim();

                    string img = dt.Rows[0]["AllotteeImage"].ToString();

                    string imgSign = dt.Rows[0]["AllotteeSign"].ToString();
                    if (img.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeImage"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrv.Attributes.Add("class", "hide");
                        Image1.Visible = true;
                        Image1.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }

                    if (imgSign.ToString().Length > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["AllotteeSign"];
                        ViewState["content"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImgPrvSign.Attributes.Add("class", "hide");
                        Image2.Visible = true;
                        Image2.ImageUrl = "data:" + Imagetype + ";base64," + base64String;

                    }

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Details Not Found');", true);
                    return;
                }
                if (dt_project.Rows.Count > 0)
                {
                    if (dt_project.Rows[0]["TypeOfProject"].ToString().Trim().Length > 0)
                    {
                        ddlTypeProject.Items.FindByText(dt_project.Rows[0]["TypeOfProject"].ToString().Trim()).Selected = true;
                    }
                    if (dt_project.Rows[0]["CategoryOfProject"].ToString().Trim().Length > 0)
                    {
                        ddlCategoryProject.Items.FindByText(dt_project.Rows[0]["CategoryOfProject"].ToString().Trim()).Selected = true;
                    }

                    txtDateofCompletion.Text = dt_project.Rows[0]["DateofCompletion"].ToString();
                    txtDateCapitalInvestment.Text = dt_project.Rows[0]["datewhencapitalinvestmentstarted"].ToString();
                    txtProposedInvestment.Text = dt_project.Rows[0]["ProposedInvestment"].ToString();
                    
                    txtDistanceFromRailway.Text = dt_project.Rows[0]["DistanceFromRailway"].ToString();
                    txtProposedDirectEmployment.Text = dt_project.Rows[0]["ProposedDirectEmployment"].ToString();
                    txtDistanceFromBus.Text = dt_project.Rows[0]["DistanceFromBus"].ToString();
                    txtProposedIndirectEmployment.Text = dt_project.Rows[0]["ProposedIndirectEmployment"].ToString();
                    txtDistanceFromAirport.Text = dt_project.Rows[0]["DistanceFromAirport"].ToString();

                    txtTotalAmountRequested.Text = dt_project.Rows[0]["TotalAmountrequestedbyApplicant"].ToString();
                    txtExemptionOnStamp.Text = dt_project.Rows[0]["ExemptionOnStamp"].ToString();
                    txtSubsidyFixedCapitalInvestment.Text = dt_project.Rows[0]["SubsidyFixedCapitalInvestment"].ToString();
                    txtSubsidyHostelDormitory.Text = dt_project.Rows[0]["SubsidyHostelDormitory"].ToString();
                    txtTotalArea.Text = dt_project.Rows[0]["TotalArea"].ToString();
                    txtCoveredArea.Text = dt_project.Rows[0]["CoveredArea"].ToString();
                    //txtPIPRegistrationNo.Text = dt_project.Rows[0]["PIPRegistrationNo"].ToString();
                    ddlProjectDetails.SelectedItem.Text = dt_project.Rows[0]["ProjectDetail"].ToString();
                    if (ddlProjectDetails.SelectedItem.Text == "Any Other")
                    {
                        txtAnyOther.Text = dt_project.Rows[0]["anyOthers"].ToString();
                    }


                    CheckNMSWPFeePaid123();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }

        }
        protected void BtnSaveApplicant_Click(object sender, EventArgs e)
        {
            try
            {
                int retval = 0, retVal2 = 0;

                DataTable Dt1 = (DataTable)ViewState["temp_shareholder_details"];
                DataTable Dt2 = (DataTable)ViewState["temp_trustee_details"];
                DataTable Dt3 = (DataTable)ViewState["temp_directors_details"];
                DataTable Dt4 = (DataTable)ViewState["temp_partnership_details"];


                if (txtApplicantAadhar.Text.Trim().Length == 12)
                {

                    bool isValidnumber = aadharcard.validateVerhoeff(txtApplicantAadhar.Text.Trim());
                    if (isValidnumber)
                    {

                    }
                    else
                    {
                        string message = "Invalid Aadhaar Number";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;

                    }
                }
                else
                {
                    string message = "Enter your aadhar no";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }

                if (ddlcompanytype.SelectedIndex == 2)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                else if (ddlcompanytype.SelectedIndex == 3)
                {
                    if (Dt3.Rows.Count <= 0)
                    {
                        string message = "Please Add Directors Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                else if (ddlcompanytype.SelectedIndex == 4)
                {
                    if (Dt2.Rows.Count <= 0)
                    {
                        string message = "Please Add Trustee Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }
                else if (ddlcompanytype.SelectedIndex == 5)
                {
                    if (Dt4.Rows.Count <= 0)
                    {
                        string message = "Please Add Partners Details.By Clicking Add button at the Below Section";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                }



                DataSet ds = new DataSet();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                objServiceTimelinesBEL.CreatedBy = System.Environment.MachineName;
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.FirmConstitution = ddlcompanytype.SelectedValue.Trim();
                objServiceTimelinesBEL.PanNo = txtPanNo.Text.Trim().ToUpper();
                objServiceTimelinesBEL.CompanyName = txtCompanyname.Text.Trim();
                objServiceTimelinesBEL.GSTNo = txtGstNo.Text.Trim();
                objServiceTimelinesBEL.UdyogAadharNo = txtUdyogAdhar.Text.Trim();
                objServiceTimelinesBEL.Address = txtProjectLocation.Text.Trim();
                objServiceTimelinesBEL.applicantAddress = txtApplicantAddress.Text.Trim();
                objServiceTimelinesBEL.AadharNo = txtApplicantAadhar.Text.Trim();
                objServiceTimelinesBEL.CompanyAddress = txtFirmAddress.Text.Trim();

                objServiceTimelinesBEL.IsSPV = drpSPV.SelectedValue.Trim();

                //-Added by Sunil - PIP 
                objServiceTimelinesBEL.IsRegionPIP = drpRegionPIP.SelectedValue.Trim();
                objServiceTimelinesBEL.ProposedPIP = txtProposedPIP.Text.Trim();
                objServiceTimelinesBEL.AllotteeName = lblApplicantName.Text.Trim();
                objServiceTimelinesBEL.emailID = lblEmailID.Text.Trim();
                objServiceTimelinesBEL.PhoneNo = lblMobileNo.Text.Trim();

                ds = objServiceTimelinesBLL.UpdateApplicantPIPBasicDetails(objServiceTimelinesBEL);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LblAllotteeId.Text = ds.Tables[0].Rows[0][0].ToString();
                        objServiceTimelinesBEL.AllotteeID = Convert.ToInt32(LblAllotteeId.Text.Trim());
                        retVal2 = objServiceTimelinesBLL.ClearFirmConstitutionPIP(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            if (ddlcompanytype.SelectedValue == "1")
                            {
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                Allotment.ActiveViewIndex = 1;
                            }
                            else if (ddlcompanytype.SelectedValue == "2")
                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;

                                        retval = objServiceTimelinesBLL.SaveDirectorsDetailsPIP(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            else if (ddlcompanytype.SelectedValue == "3")

                            {
                                DataTable temp = (DataTable)ViewState["temp_directors_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string DirectorName = dr1["DirectorName"].ToString();
                                        string din_pan = dr1["Din_Pan"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.DirectorName = DirectorName.Trim();
                                        objServiceTimelinesBEL.DirectorAddress = Address.Trim();
                                        objServiceTimelinesBEL.DirectorPhone = phone.Trim();
                                        objServiceTimelinesBEL.DirectorEmail = email.Trim();
                                        objServiceTimelinesBEL.DirectorDinPan = din_pan;

                                        retval = objServiceTimelinesBLL.SaveDirectorsDetailsPIP(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            else if (ddlcompanytype.SelectedValue == "4")
                            {
                                DataTable temp = (DataTable)ViewState["temp_trustee_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string TrusteeName = dr1["TrusteeName"].ToString();
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();



                                        objServiceTimelinesBEL.TrusteeName = TrusteeName.Trim();
                                        objServiceTimelinesBEL.TrusteeAddress = Address.Trim();
                                        objServiceTimelinesBEL.TrusteePhone = phone.Trim();
                                        objServiceTimelinesBEL.TrusteeEmail = email.Trim();

                                        retval = objServiceTimelinesBLL.SaveTrusteeDetailsPIP(objServiceTimelinesBEL);

                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            else if (ddlcompanytype.SelectedValue == "5")
                            {
                                DataTable temp = (DataTable)ViewState["temp_partnership_details"];
                                if (temp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in temp.Rows)
                                    {
                                        string PartnerName = dr1["PartnerName"].ToString();
                                        decimal Partnershipper = Convert.ToDecimal(dr1["PartnershipPer"].ToString());
                                        string Address = dr1["Address"].ToString();
                                        string phone = dr1["Phone"].ToString();
                                        string email = dr1["Email"].ToString();

                                        objServiceTimelinesBEL.PartnerName = PartnerName.Trim();
                                        objServiceTimelinesBEL.PartnerAddress = Address.Trim();
                                        objServiceTimelinesBEL.PartnerPhone = phone.Trim();
                                        objServiceTimelinesBEL.PartnerEmail = email.Trim();
                                        objServiceTimelinesBEL.PartnerPer = Partnershipper;

                                        retval = objServiceTimelinesBLL.SavePartnerDetailsPIP(objServiceTimelinesBEL);
                                    }

                                }
                                if (retval > 0)
                                {
                                    string message = "Applicant Details Saved Successfully";
                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                    Allotment.ActiveViewIndex = 1;
                                }
                            }
                            else if (ddlcompanytype.SelectedValue == "6")
                            {
                                string message = "Applicant Details Saved Successfully";
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                                Allotment.ActiveViewIndex = 1;
                            }

                        }


                    }
                }
                else
                {
                    string message = "Record could'nt be Save ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    return;
                }
            }



            catch (Exception ex)
            {


                Response.Write("Oops! error occured :" + ex.Message.ToString());

            }
        }
        protected void BtnProjectInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");

                string date_to_be11 = DateTime.ParseExact(txtDateofCompletion.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                string date_to_be12 = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                if (Convert.ToDateTime(date_to_be12) > Convert.ToDateTime(date_to_be11))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter Completion Date greater than todays date.');", true);
                    return;
                }
                else
                {

                    int retval = 0;
                    string date_to_be = DateTime.ParseExact(txtDateofCompletion.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    string date_to_be1 = DateTime.ParseExact(txtDateCapitalInvestment.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();

                    objServiceTimelinesBEL.ProposedArea = txtTotalArea.Text.Trim();
                    objServiceTimelinesBEL.ProposedCoveredArea = txtCoveredArea.Text.Trim();

                    objServiceTimelinesBEL.TypeOfProject = ddlTypeProject.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.CategoryOfProject = ddlCategoryProject.SelectedItem.Text.Trim();
                    objServiceTimelinesBEL.DateofCompletion = date_to_be.Trim();
                    objServiceTimelinesBEL.datewhencapitalinvestmentstarted = Convert.ToDateTime(date_to_be1.Trim());
                    objServiceTimelinesBEL.ProposedInvestment = txtProposedInvestment.Text.Trim();
                    objServiceTimelinesBEL.ProjectDetail = ddlProjectDetails.SelectedItem.Text.Trim();

                    objServiceTimelinesBEL.DistanceFromRailway = txtDistanceFromRailway.Text.Trim();
                    objServiceTimelinesBEL.ProposedDirectEmployment = txtProposedDirectEmployment.Text.Trim();
                    objServiceTimelinesBEL.DistanceFromBus = txtDistanceFromBus.Text.Trim();
                    objServiceTimelinesBEL.ProposedIndirectEmployment = txtProposedIndirectEmployment.Text.Trim();
                    objServiceTimelinesBEL.DistanceFromAirport = txtDistanceFromAirport.Text.Trim();

                    objServiceTimelinesBEL.TotalAmountrequestedbyApplicant = txtTotalAmountRequested.Text.Trim();

                    objServiceTimelinesBEL.ExemptionOnStamp = txtExemptionOnStamp.Text.Trim();
                    objServiceTimelinesBEL.SubsidyFixedCapitalInvestment = txtSubsidyFixedCapitalInvestment.Text.Trim();
                    objServiceTimelinesBEL.SubsidyHostelDormitory = txtSubsidyHostelDormitory.Text.Trim();

                    objServiceTimelinesBEL.PIPRegistrationNo = txtPIPRegistrationNo.Text.Trim();
                    objServiceTimelinesBEL.anyOther = txtAnyOther.Text.Trim();
                    
                    retval = objServiceTimelinesBLL.UpdateApplicantProjectDetailsPIP(objServiceTimelinesBEL);


                    string message = "Applicant Project Details Saved Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                    Allotment.ActiveViewIndex = 3;
                }
            }
            catch (Exception ex)
            {

                // Response.Write("Oops! error occured :" + ex.Message.ToString());
                string msg = "Oops! error occured :" + ex.Message.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
            }
        }

        private void DisableAllControl()
        {
            txtApplicantAadhar.Enabled = false;
            txtApplicantAddress.Enabled = false;
            ddlcompanytype.Enabled = false;
            drpSPV.Enabled = false;
            txtCompanyname.Enabled = false;
            txtFirmAddress.Enabled = false;
            txtPanNo.Enabled = false;
            txtGstNo.Enabled = false;
            txtUdyogAdhar.Enabled = false;
            txtProposedPIP.Enabled = false;
            txtProjectLocation.Enabled = false;
            drpRegionPIP.Enabled = false;
            BtnSaveApplicant.Enabled = false;

            GridView2.Enabled = false;
            Trustee_details_grid.Enabled = false;
            DirectorsGrid.Enabled = false;
            PartnershipFirmGrid.Enabled = false;
            Grid_LandDetails.Enabled = false;
            gridshareholder.Enabled = false;

            FuplodApplicantImage.Enabled = false;
            FuplodApplicantSign.Enabled = false;
            btnSaveSign.Disabled = true;
            btnSaveImage.Disabled = true;
            
            txtTotalArea.Enabled = false;
            txtCoveredArea.Enabled = false;
            ddlTypeProject.Enabled = false;
            ddlCategoryProject.Enabled = false;
            txtDateofCompletion.Enabled = false;
            txtDateCapitalInvestment.Enabled = false;
            txtProposedInvestment.Enabled = false;
            ddlProjectDetails.Enabled = false;
            txtDistanceFromRailway.Enabled = false;
            txtProposedDirectEmployment.Enabled = false;
            txtDistanceFromBus.Enabled = false;
            txtProposedIndirectEmployment.Enabled = false;
            txtDistanceFromAirport.Enabled = false;
            txtTotalAmountRequested.Enabled = false;
            txtExemptionOnStamp.Enabled = false;
            txtSubsidyFixedCapitalInvestment.Enabled = false;
            txtSubsidyHostelDormitory.Enabled = false;
            Button1.Enabled = false;

            ddlDistrict.Enabled = false;
            txtDistrict.Enabled = false;
            txtTehsil.Enabled = false;
            txtVillage.Enabled = false;
            txtLandDeedDate.Enabled = false;
            txtLandArea.Enabled = false;
            txtKhasraNo.Enabled = false;
            txtValueOfLand.Enabled = false;
            txtStampDutyPaid.Enabled = false;
            ddlExistingLand.Enabled = false;
            ddlLandContiguous.Enabled = false;
            txtLandContiguous.Enabled = false;
            ddlGramGov.Enabled = false;
            txtGramGov.Enabled = false;
            ddlLandExchange.Enabled = false;
            txtLandExchange.Enabled = false;
            txtPIPOtherDetails.Enabled = false;
            btnAddLandDetails.Enabled = false;
            btnClearLandDetails.Enabled = false;
            divLand.Visible = false;
            Conform_CheckBox_multiview_1.Enabled = false;
            btnDocConfirm.Enabled = false;

            btnConfirm.Enabled = false;
            btn_final.Visible = false;

            btnPay.Enabled = false;


        }

        protected void btnSaveImage_ServerClick(object sender, EventArgs e)
        {
            int maxFileSize = 10;

            if (FuplodApplicantImage.HasFile)
            {
                string filePath = FuplodApplicantImage.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantImage.FileName.ToString());
                string filename = Path.GetFileName(filePath);
                string contenttype = String.Empty;

                int fileSize = FuplodApplicantImage.PostedFile.ContentLength;
                if (fileSize > (maxFileSize * 1024 * 1024))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Filesize of image is too large. Max size allowed is 20 MB');", true);
                    GetApplicantDetails(ServiceReqNo);

                    return;
                }

                switch (fleUpload)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".jpeg":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/JPEG";
                        break;
                    case ".JPG":
                        contenttype = "image/JPG";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;

                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantImage.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;


                    int result;
                    result = objServiceTimelinesBLL.SaveApplicantImagePIP(objServiceTimelinesBEL);

                    if (result > 0)
                    {

                        string message = "Image Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }
        protected void btnSaveSign_ServerClick(object sender, EventArgs e)
        {
            int maxFileSize = 10;
            if (FuplodApplicantSign.HasFile)
            {
                string filePath = FuplodApplicantSign.PostedFile.FileName;
                string fleUpload = Path.GetExtension(FuplodApplicantSign.FileName.ToString());
                string filename = Path.GetFileName(filePath);
                string contenttype = String.Empty;

                int fileSize = FuplodApplicantImage.PostedFile.ContentLength;
                if (fileSize > (maxFileSize * 1024 * 1024))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Filesize of image is too large. Max size allowed is 20 MB');", true);
                    GetApplicantDetails(ServiceReqNo);

                    return;
                }
                switch (fleUpload)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".jpeg":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/JPEG";
                        break;
                    case ".JPG":
                        contenttype = "image/JPG";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;

                }
                if (contenttype != String.Empty)
                {
                    Stream fs = FuplodApplicantSign.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    DataSet ds = new DataSet();
                    objServiceTimelinesBEL.ApplicantImageByte = bytes;
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ApplicantImageName = filename;
                    objServiceTimelinesBEL.ImageContent = contenttype;


                    int result;
                    result = objServiceTimelinesBLL.SaveApplicantSignPIP(objServiceTimelinesBEL);


                    if (result > 0)
                    {

                        string message = "Signature Uploaded Successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        GetApplicantDetails(ServiceReqNo);

                    }
                }
                else
                {
                    string message = "Invalid File Format";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }


            }

            else
            {
                string message = "Please Select Image To Upload ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


            }
        }


        protected void btn_final_Click(object sender, EventArgs e)
        {
            final_Save();
        }

        public void final_Save()
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                SqlCommand cmd = new SqlCommand("[ValidatePIPDetailsAndDocuments] '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0][0].ToString();
                    string ApplicantImg = dt.Rows[0][1].ToString();
                    string ApplicantSign = dt.Rows[0][2].ToString();
                    string Project = dt.Rows[0][4].ToString();
                    int LandDetails = Convert.ToInt32(dt.Rows[0][5].ToString());
                    int DocCount = Convert.ToInt32(dt.Rows[0][3].ToString());


                    if (Conform_CheckBox_multiview_1.Checked == false)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                        return;
                    }
                    if (ApplicantName.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter the basic details of first page');", true);
                        Allotment.ActiveViewIndex = 0;
                        return;
                    }
                    // if (ApplicantImg.Length <= 0)
                    // {
                    //     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your recent photograph on the second page.');", true);
                    //      Allotment.ActiveViewIndex = 1;
                    //       return;
                    //}
                    if (ApplicantSign.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your signature on the second page.');", true);
                        Allotment.ActiveViewIndex = 1;
                        return;
                    }
                    if (Project.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your project details on the Third page.');", true);
                        Allotment.ActiveViewIndex = 2;
                        return;
                    }
                    if (LandDetails <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter land bifircation details on the fourth page.');", true);
                        Allotment.ActiveViewIndex = 3;
                        return;
                    }
                    if (DocCount < 10)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload all your documents.');", true);
                        Allotment.ActiveViewIndex = 4;
                        return;
                    }


                    int retVal2 = 0;
                    objServiceTimelinesBEL.KYCID = ServiceReqNo;
                    retVal2 = objServiceTimelinesBLL.FormFinalSubmissionPIP(objServiceTimelinesBEL);
                    if (retVal2 >= 0)
                    {
                        string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo));
                        niveshmitrastatusupdate();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect('" + ID.Trim() + "');", true);
                        return;
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Form Not Submitted');", true);
                        return;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void final_Save_doc()
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                SqlCommand cmd = new SqlCommand("[ValidatePIPDetailsAndDocuments] '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0][0].ToString();
                    string ApplicantImg = dt.Rows[0][1].ToString();
                    string ApplicantSign = dt.Rows[0][2].ToString();
                    string Project = dt.Rows[0][4].ToString();
                    int LandDetails = Convert.ToInt32(dt.Rows[0][5].ToString());
                    int DocCount = Convert.ToInt32(dt.Rows[0][3].ToString());


                    if (Conform_CheckBox_multiview_1.Checked == false)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                        return;
                    }
                    if (DocCount < 10)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload all your documents.');", true);
                        //Allotment.ActiveViewIndex = 4;
                        return;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void check_final_Save()
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                SqlCommand cmd = new SqlCommand("[ValidatePIPDetailsAndDocuments] '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0][0].ToString();
                    string ApplicantImg = dt.Rows[0][1].ToString();
                    string ApplicantSign = dt.Rows[0][2].ToString();
                    string Project = dt.Rows[0][4].ToString();
                    int LandDetails = Convert.ToInt32(dt.Rows[0][5].ToString());
                    int DocCount = Convert.ToInt32(dt.Rows[0][3].ToString());


                    if (Conform_CheckBox_multiview_1.Checked == false)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                        return;
                    }
                    if (ApplicantName.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter the basic details of first page');", true);
                        Allotment.ActiveViewIndex = 0;
                        return;
                    }
                    // if (ApplicantImg.Length <= 0)
                    // {
                    //     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your recent photograph on the second page.');", true);
                    //      Allotment.ActiveViewIndex = 1;
                    //       return;
                    //}
                    if (ApplicantSign.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your signature on the second page.');", true);
                        Allotment.ActiveViewIndex = 1;
                        return;
                    }
                    if (Project.Length <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your project details on the Third page.');", true);
                        Allotment.ActiveViewIndex = 2;
                        return;
                    }
                    if (LandDetails <= 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter land bifircation details on the fourth page.');", true);
                        Allotment.ActiveViewIndex = 3;
                        return;
                    }
                    if (DocCount < 10)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload all your documents.');", true);
                        Allotment.ActiveViewIndex = 4;
                        return;
                    }

                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Form Not Submitted');", true);
                        return;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void fetchNMdetails()
        {
            try
            {

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceRequests WHERE ServiceRequestNO ='" + ServiceReqNo + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ControlID = sdr["NMControlID"].ToString();
                            UnitID = sdr["NMUnitId"].ToString();
                            ServiceID = sdr["NMServiceId"].ToString();

                            RequestID = sdr["NMRequestID"].ToString();
                            isActive = sdr["isActive"].ToString();
                            //  DocPath = sdr["DocPath"].ToString();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void niveshmitrastatusupdate()
        {

            try
            {


                fetchNMdetails();

                Status_Code = "05";
                Remarks = "Application Forwarded to Nodal Officer PIP";

                string Result = gm.UpdateStatusAtNMSWP(ControlID, UnitID, ServiceID, "05", "Application Forwarded to Nodal Officer PIP", RequestID, "Pending At Nodal Officer PIP", "");
                if (Result == "SUCCESS")
                {

                }
                else
                {

                }

                //            ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                //            string Update_Result = webService.WReturn_CUSID_STATUS(
                //            ControlID,
                //            UnitID,
                //            ServiceID,
                //            ProcessIndustryID,
                //            ApplicationID,
                //            Status_Code,
                //            Remarks,
                //            "Pending At Nodal Officer PIP",
                //            Fee_Amount,
                //            Fee_Status,
                //            Transaction_ID,
                //            Transaction_Date,
                //            Transaction_Date_Time,
                //            ServiceReqNo,
                //            NOC_URL,
                //            ISNOC_URL_ActiveYesNO,
                //            passsalt,
                //            RequestID,
                //            Objection_Rejection_Code,
                //            "Yes",
                //            Certificate_EXP_Date_DDMMYYYY,
                //D1,
                //D2,
                //D3,
                //D4,
                //D5,
                //D6,
                //D7
                //            );

            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }
        }

        private void BindMakeP()
        {
            try
            {

                fetchNMdetails();
                GeneralMethod gm = new GeneralMethod();
                DataSet Pay_Ds = new DataSet(); DataTable Paymentdt = new DataTable();
                string PayMode = string.Empty, Pay = string.Empty;
                lblSERviceNo.Text = ServiceReqNo;
                lblAName.Text = txtCompanyname.Text;
                lblPAddress.Text = txtFirmAddress.Text;
                //GeneralMethod gm = new GeneralMethod();
                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;


                Pay_Ds = objServiceTimelinesBLL.GetTransactionDetailsNMSWPPIP(objServiceTimelinesBEL);
                Paymentdt = Pay_Ds.Tables[0];


                if (Paymentdt.Rows.Count > 0)
                {
                    PayMode = "Nivesh Mitra Payment Gateway";
                    lblTransactionNo.Text = Paymentdt.Rows[0]["Transaction_ID"].ToString();
                    lblPayDate.Text = Paymentdt.Rows[0]["Transaction_Date"].ToString();

                    DateTime dt1222 = DateTime.Parse(Paymentdt.Rows[0]["Transaction_Date"].ToString());
                    //Console.WriteLine(dt1222.ToString("dd/MM/yyyy"));

                    lblPayDateD.Text = dt1222.ToString("dd/MM/yyyy");
                    Pay = Paymentdt.Rows[0]["Fee_Status"].ToString();
                    if (Pay.Trim() == "Paid")
                    {
                        lblPaystatus.Text = "Payment Completed";

                    }
                    else
                    {
                        lblPaystatus.Text = "Payment Pending At NMSWP";
                        btn_final.Visible = false;

                    }
                }
                else
                {


                    //objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    //objServiceTimelinesBEL.ServiceId = ServiceID;
                    //objServiceTimelinesBEL.ControlId = ControlID;
                    //objServiceTimelinesBEL.UnitId = UnitID;
                    //objServiceTimelinesBEL.MRequestID = RequestID;
                    //objServiceTimelinesBEL.TEFFees = 11800;                

                    //int retVal = objServiceTimelinesBLL.SaveTransactionDetailsNMSWPPIP(objServiceTimelinesBEL);
                    //if (retVal > 0)
                    //{
                    //btnPay.Text = "Pay Now";
                    //lblPaystatus.Text = "Payment Pending At NMSWP";                   
                    //}
                }
                //if (lblPaystatus.Text == "Payment Pending At NMSWP")
                if (Pay.Trim() == "Paid")
                {
                    //btn_Submit.Text = "Print";
                    btnPay.Text = "Print";
                    // DocDisable.Text = "Lock";
                    DisableAllControl();

                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        //-Sunil- 
                        if (item.Text == "Final Form")
                            //-Sunil- 
                            menuItem = item;
                    }
                    ////menuItems.Remove(menuItem);

                    
                }
                else if (Pay.Trim() == "Pending")
                {
                    // btn_Submit.Text = "Print";
                    btnPay.Text = "Pay Now";
                    //--btnPay.Text = "Print";
                    //DocDisable.Text = "Lock";
                    //DisableAllControl();
                    MenuItemCollection menuItems = sub_menu.Items;
                    MenuItem menuItem = new MenuItem();
                    foreach (MenuItem item in menuItems)
                    {
                        //-Sunil- 
                        if (item.Text == "Final Form")
                            //-Sunil- 
                            menuItem = item;
                    }
                    ////menuItems.Remove(menuItem);
                    //btn_final.Visible = false;
                }

                


            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "" + ex.Message + "", true);

            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (btnPay.Text == "Print")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "PrintElem()", true);



            }
            else if (btnPay.Text == "Pay Now")
            {

                try
                {
                    belBookDetails objServiceTimelinesBEL = new belBookDetails();
                    BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                    SqlCommand cmd = new SqlCommand("[ValidatePIPDetailsAndDocuments] '" + ServiceReqNo.Trim() + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string ApplicantName = dt.Rows[0][0].ToString();
                        string ApplicantImg = dt.Rows[0][1].ToString();
                        string ApplicantSign = dt.Rows[0][2].ToString();
                        string Project = dt.Rows[0][4].ToString();
                        int LandDetails = Convert.ToInt32(dt.Rows[0][5].ToString());
                        int DocCount = Convert.ToInt32(dt.Rows[0][3].ToString());


                        if (Conform_CheckBox_multiview_1.Checked == false)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                            return;
                        }
                        if (ApplicantName.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter the basic details of first page');", true);
                            Allotment.ActiveViewIndex = 0;
                            return;
                        }
                        // if (ApplicantImg.Length <= 0)
                        // {
                        //     System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your recent photograph on the second page.');", true);
                        //      Allotment.ActiveViewIndex = 1;
                        //       return;
                        //}
                        if (ApplicantSign.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload your signature on the second page.');", true);
                            Allotment.ActiveViewIndex = 1;
                            return;
                        }
                        if (Project.Length <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter your project details on the Third page.');", true);
                            Allotment.ActiveViewIndex = 2;
                            return;
                        }
                        if (LandDetails <= 0)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please enter land bifircation details on the fourth page.');", true);
                            Allotment.ActiveViewIndex = 3;
                            return;
                        }
                        if (DocCount < 11)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload all your documents.');", true);
                            Allotment.ActiveViewIndex = 4;
                            return;
                        }


                        btnPay.Text = "Print";
                        fetchNMdetails();
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.ServiceId = ServiceID;
                        objServiceTimelinesBEL.ControlId = ControlID;
                        objServiceTimelinesBEL.UnitId = UnitID;
                        objServiceTimelinesBEL.MRequestID = RequestID;
                        objServiceTimelinesBEL.TEFFees = 11800;

                        int retVal = objServiceTimelinesBLL.SaveTransactionDetailsNMSWPPIP(objServiceTimelinesBEL);
                        if (retVal > 0)
                        {
                            lblPaystatus.Text = "Payment Pending At NMSWP";
                        }

                        //For Service Request Track Allottee to Nodal Officer

                        int retVal3 = 0;
                        DataSet ds = new DataSet();
                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.TransferFrom = "Applicant";
                        objServiceTimelinesBEL.TransferTo = "KN_Srivastava";
                        objServiceTimelinesBEL.FromUser = "Applicant";
                        objServiceTimelinesBEL.Comments = "Application Submitted to Nodal Officer";
                        objServiceTimelinesBEL.TransferPIPCommStatus = "Application Submitted";
                        //filePath = "";
                        objServiceTimelinesBEL.LAWDocPath = "";
                        retVal3 += objServiceTimelinesBLL.TransferApplicationPIP(objServiceTimelinesBEL);
                        if (retVal3 > 0)
                        {
                        }

                        //For Service Request Track Allottee to Nodal Officer

                        string NMSWP_Result = niveshmitrastatusupdatePIP();
                        if (NMSWP_Result == "SUCCESS")
                        {
                            int retVal11 = objServiceTimelinesBLL.SaveTransactionDetailsNMSWPPIPCom(objServiceTimelinesBEL);
                            if (retVal11 > 0)
                            {
                                lblPaystatus.Text = "Payment Completed";
                            }


                            /*need to confirm*/
                            
                            CheckNMSWPFeePaid();

                            int retVal2 = 0;
                            objServiceTimelinesBEL.KYCID = ServiceReqNo;
                            retVal2 = objServiceTimelinesBLL.FormFinalSubmissionPIP(objServiceTimelinesBEL);
                            if (retVal2 >= 0)
                            {
                                
                                string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo));
                                niveshmitrastatusupdate();
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirect('" + ID.Trim() + "');", true);
                                return;
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Your Form Not Submitted');", true);
                                return;
                            }
                            /*need to confirm*/


                            MenuItemCollection menuItems = sub_menu.Items;
                            MenuItem menuItem = new MenuItem();
                            foreach (MenuItem item in menuItems)
                            {
                                //-Sunil- 
                                if (item.Text == "Final Form")
                                    //-Sunil- 
                                    menuItem = item;
                            }
                            ////menuItems.Remove(menuItem);
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Request is submitted successfully. Kindly pay processing fees Nivesh Mitra Portal for the final submission of your application.", true);
                        }
                        else
                        {
                            string message = "Error occured while updating status at NMSWP";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            return;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Error:" + ex);
                }
            }
        }
        private void GetFirstView()
        {
            UC_ApplicationFinalViewPIP UC_ApplicationFinalViewPIP = LoadControl("~/UC_ApplicationFinalViewPIP.ascx") as UC_ApplicationFinalViewPIP;
            UC_ApplicationFinalViewPIP.ID = "UC_ApplicationFinalViewPIP";
            UC_ApplicationFinalViewPIP.ServiceRequestNo = ServiceReqNo;
            PH_FinalView.Controls.Add(UC_ApplicationFinalViewPIP);

            //UC_ApplicationFinalViewLAW UC_ApplicationFinalViewLAW = LoadControl("~/UC_ApplicationFinalViewPIP.ascx") as UC_ApplicationFinalViewLAW;
            //UC_ApplicationFinalViewLAW.ID = "UC_ApplicationFinalViewLAW";
            //UC_ApplicationFinalViewPIP.ServiceRequestNo = ServiceReqNo;
            //PH_FinalView.Controls.Add(UC_ApplicationFinalViewPIP);

        }

        public string niveshmitrastatusupdatePIP()
        {
            string Update_Result = "";
            try
            {


                fetchNMdetails();

                Status_Code = "12";
                Remarks = "Fee Payment is Pending Kindly Pay Fees for the final submission: Applicant";

                ServiceReference1.upswp_niveshmitraservicesSoapClient webService = new ServiceReference1.upswp_niveshmitraservicesSoapClient();
                Update_Result = webService.WReturn_CUSID_STATUS(
                ControlID,
                UnitID,
                ServiceID,
                ProcessIndustryID,
                ApplicationID,
                Status_Code,
                Remarks,
                "Applicant",
                "11800",
                "UB",
                Transaction_ID,
                Transaction_Date,
                Transaction_Date_Time,
                ServiceReqNo,
                NOC_URL,
                ISNOC_URL_ActiveYesNO,
                passsalt,
                RequestID,
                Objection_Rejection_Code,
                "",
                Certificate_EXP_Date_DDMMYYYY,
    D1,
    D2,
    D3,
    D4,
    D5,
    D6,
    D7
                );

                /** BY Sunil

                if (Update_Result == "SUCCESS")
                {
                    fetchNMdetails();
                    TEFFeeStatus = "Paid";
                    objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                    objServiceTimelinesBEL.ServiceId = ServiceID;
                    objServiceTimelinesBEL.ControlId = ControlID;
                    objServiceTimelinesBEL.UnitId = UnitID;
                    objServiceTimelinesBEL.MRequestID = RequestID;
                    objServiceTimelinesBEL.TEFFees = 11800;
                    //objServiceTimelinesBEL.TEFFeeStatus = TEFFeeStatus;

                    int retVal = objServiceTimelinesBLL.UpdateTransactionDetailsNMSWPPIP(objServiceTimelinesBEL);
                    /**
                    if (retVal > 0)
                    {
                        //btnPay.Text = "Pay Now";
                        //niveshmitrastatusupdatePIP();
                        lblPaystatus.Text = "Payment Pending At NMSWP";
                    }
                    string NMSWP_Result = niveshmitrastatusupdatePIP();
                    if (NMSWP_Result == "SUCCESS")
                    {
                        MenuItemCollection menuItems = sub_menu.Items;
                        MenuItem menuItem = new MenuItem();
                        foreach (MenuItem item in menuItems)
                        {
                            //-Sunil- 
                            if (item.Text == "Final Form")
                                //-Sunil- 
                                menuItem = item;
                        }
                        menuItems.Remove(menuItem);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "Request is submitted successfully. Kindly pay processing fees Nivesh Mitra Portal for the final submission of your application.", true);
                    }
                    else
                    {
                        string message = "Error occured while updating status at NMSWP";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                        return;
                    }
                   */ 
             /**   }
            **/

            }

            catch (Exception ex)
            {
                Response.Write("Error:" + ex);
            }

            return Update_Result;
        }
        private void GetFinalView()
        {

            UC_ApplicationFinalViewPIP UC_ApplicationFinalViewPIP = LoadControl("~/UC_ApplicationFinalViewPIP.ascx") as UC_ApplicationFinalViewPIP;
            UC_ApplicationFinalViewPIP.ID = "UC_ApplicationFinalViewPIP";
            UC_ApplicationFinalViewPIP.ServiceRequestNo = ServiceReqNo;
            PH_FinalView.Controls.Add(UC_ApplicationFinalViewPIP);

        }
        private void BindObjection()
        {
            PH_Objection.Controls.Clear();
            UC_ResolveObjectionPIP UC_ResolveObjectionPIP = LoadControl("~/UC_ResolveObjectionPIP.ascx") as UC_ResolveObjectionPIP;
            UC_ResolveObjectionPIP.ID = "UC_ResolveObjectionPIP";
            UC_ResolveObjectionPIP.ServiceReqNo = ServiceReqNo;
            PH_Objection.Controls.Add(UC_ResolveObjectionPIP);
        }


        public void Redirect(string Par)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MessageAndRedirect('" + HttpUtility.UrlEncode(Encrypt(ServiceReqNo)) + "');", true);
        }
        protected void Grid_LandDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                index = index % Grid_LandDetails.PageSize;

                var b = Grid_LandDetails.Rows[index].Cells[1].Text;
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(b));

                lblRecordID.Text = Grid_LandDetails.DataKeys[index].Values[0].ToString();
                //txtDistrict.Text = Grid_LandDetails.Rows[index].Cells[1].Text;
                txtTehsil.Text = Grid_LandDetails.Rows[index].Cells[2].Text;
                txtVillage.Text = Grid_LandDetails.Rows[index].Cells[3].Text;
                txtLandDeedDate.Text = Grid_LandDetails.Rows[index].Cells[4].Text;
                txtLandArea.Text = Grid_LandDetails.Rows[index].Cells[5].Text;
                txtKhasraNo.Text = Grid_LandDetails.Rows[index].Cells[6].Text;
                txtValueOfLand.Text = Grid_LandDetails.Rows[index].Cells[7].Text;
                txtStampDutyPaid.Text = Grid_LandDetails.Rows[index].Cells[8].Text;

                var b1 = Grid_LandDetails.Rows[index].Cells[9].Text;
                ddlExistingLand.SelectedIndex = ddlExistingLand.Items.IndexOf(ddlExistingLand.Items.FindByText(b1));
                if (b1 == "Other")
                {
                    anyOtherExistingProject.Visible = true;
                    anyOtherExistingProject.Text = Grid_LandDetails.Rows[index].Cells[10].Text;
                }
                else
                {
                    anyOtherExistingProject.Visible = false;
                }

                var b2 = Grid_LandDetails.Rows[index].Cells[11].Text;
                ddlLandContiguous.SelectedIndex = ddlLandContiguous.Items.IndexOf(ddlLandContiguous.Items.FindByText(b2));

                if (b2 == "No")
                {
                    txtLandContiguous.Visible = true;
                    txtLandContiguous.Text = Grid_LandDetails.Rows[index].Cells[12].Text;
                }
                else
                {
                    txtLandContiguous.Visible = false;
                }


                var b3 = Grid_LandDetails.Rows[index].Cells[13].Text;
                ddlGramGov.SelectedIndex = ddlGramGov.Items.IndexOf(ddlGramGov.Items.FindByText(b3));
                if (b3 == "Yes")
                {
                    txtGramGov.Visible = true;
                    txtGramGov.Text = Grid_LandDetails.Rows[index].Cells[14].Text;
                }
                else
                {
                    txtGramGov.Visible = false;
                }

                var b4 = Grid_LandDetails.Rows[index].Cells[15].Text;
                ddlLandExchange.SelectedIndex = ddlLandExchange.Items.IndexOf(ddlLandExchange.Items.FindByText(b4));
                if (b4 == "Yes")
                {
                    txtLandExchange.Visible = true;
                    txtLandExchange.Text = Grid_LandDetails.Rows[index].Cells[16].Text;
                }
                else
                {
                    txtLandExchange.Visible = false;
                }

                txtPIPOtherDetails.Text = Grid_LandDetails.Rows[index].Cells[17].Text;

                btnAddLandDetails.Text = "Update Detail";

            }
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                rowIndex = rowIndex % Grid_LandDetails.PageSize;
                string ID = Grid_LandDetails.DataKeys[rowIndex].Values[0].ToString();

                objServiceTimelinesBEL.LAWLandID = ID;
                try
                {
                    int retVal = objServiceTimelinesBLL.DeletePIPLandDetail(objServiceTimelinesBEL);

                    if (retVal > 0)
                    {

                        string msg = "Record deleted successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        BindLandDetails();
                        return;
                    }
                    else
                    {

                        string msg = "details couldn't be deleted";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Oops! error occured :" + ex.Message.ToString());
                }

            }

        }
        protected void btn_backNmswp_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://72.167.225.87/nivesh/nmmasters/Entrepreneur_Dashboard.aspx");

        }

        protected void ddlProjectDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProjectDetails.SelectedItem.Text == "Any Other")
            {
                txtAnyOther.Visible = true;
            }
            else
            {
                txtAnyOther.Visible = false;
            }
        }

        protected void ddlExistingLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExistingLand.SelectedItem.Text == "Other")
            {
                anyOtherExistingProject.Visible = true;
            }
            else
            {
                anyOtherExistingProject.Visible = false;
            }
        }



        

        protected void ddlLandContiguous_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLandContiguous.SelectedItem.Text == "No")
            {
                txtLandContiguous.Visible = true;
            }
            else
            {
                txtLandContiguous.Visible = false;
            }
        }

        protected void ddlGramGov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGramGov.SelectedItem.Text == "Yes")
            {
                txtGramGov.Visible = true;
            }
            else
            {
                txtGramGov.Visible = false;
            }
        }

        protected void ddlLandExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLandExchange.SelectedItem.Text == "Yes")
            {
                txtLandExchange.Visible = true;
            }
            else
            {
                txtLandExchange.Visible = false;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int maxFileSize = 20;
                if (FileUploadSignature.HasFile)
                {
                    string filePath = FileUploadSignature.PostedFile.FileName;
                    string fleUpload = Path.GetExtension(FileUploadSignature.FileName.ToString());
                    string filename = Path.GetFileName(filePath);
                    string contenttype = String.Empty;

                    int fileSize = FileUploadSignature.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Filesize of image is too large. Max size allowed is 20 MB');", true);
                        //GetApplicantDetails(ServiceReqNo);

                        return;
                    }
                    switch (fleUpload)
                    {
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".jpeg":
                            contenttype = "image/jpeg";
                            break;
                        case ".JPEG":
                            contenttype = "image/JPEG";
                            break;
                        case ".JPG":
                            contenttype = "image/JPG";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;

                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = FileUploadSignature.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        DataSet ds = new DataSet();
                        string DateOfClearance_be = DateTime.ParseExact(txtDateClear.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                        string DateOfProduction_be = DateTime.ParseExact(txtDateCommence.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                        string Dates_be = DateTime.ParseExact(txtDates.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);




                        objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                        objServiceTimelinesBEL.ProjectIdentification = txtProjectIden.Text;
                        objServiceTimelinesBEL.NameClearance = txtNameClear.Text;
                        objServiceTimelinesBEL.DateOfClearance = Convert.ToDateTime((DateOfClearance_be));
                        objServiceTimelinesBEL.DetailsOfIncentive = txtIncentives.Text;
                        objServiceTimelinesBEL.PresentImplementStatsu = txtImplementation.Text;
                        objServiceTimelinesBEL.DateOfProduction = Convert.ToDateTime((DateOfProduction_be));

                        objServiceTimelinesBEL.CapitaloftheLandDPR = txtLandDPR.Text;
                        objServiceTimelinesBEL.CapitaloftheLandAEI = txtLandAEI.Text;
                        objServiceTimelinesBEL.CapitaloftheBuildingDPR = txtBUILDINGDPR.Text;
                        objServiceTimelinesBEL.CapitaloftheBuildingAEI = txtBUILDINGAEI.Text;
                        objServiceTimelinesBEL.CapitalofthePlantMachineryDPR = txtPLANTDPR.Text;
                        objServiceTimelinesBEL.CapitalofthePlantMachineryAEI = txtPLANTAEI.Text;
                        objServiceTimelinesBEL.OtherCapitalDPR = txtOTHERSDPR.Text;
                        objServiceTimelinesBEL.OtherCapitalAEI = txtOTHERSAEI.Text;
                        objServiceTimelinesBEL.TotalCapitalDPR = txtTOTALDPR.Text;
                        objServiceTimelinesBEL.TotalCapitalAEI = txtTOTALAEI.Text;

                        objServiceTimelinesBEL.MeanOfFinance = txtMeansFinance.Text;
                        objServiceTimelinesBEL.Reason = txtReasonsMigration.Text;
                        objServiceTimelinesBEL.WantToMigrate = RadioButtonList1.SelectedItem.Text;
                        objServiceTimelinesBEL.Place = txtPlace.Text;
                        objServiceTimelinesBEL.Dates = Convert.ToDateTime((Dates_be));
                        // objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo;
                        objServiceTimelinesBEL.ApplicantImageName = filename;
                        objServiceTimelinesBEL.ImageContent = contenttype;
                        objServiceTimelinesBEL.ApplicantImageByte = bytes;

                        int result;
                        result = objServiceTimelinesBLL.SaveMigrationDetailsPIP(objServiceTimelinesBEL);
                        if (result > 0)
                        {
                            string message = "Migration Details Added Successfully";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);
                            GetApplicantDetails(ServiceReqNo);

                        }
                        else
                        {
                            string message = "Migration Details Not Added.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                        }
                    }
                    else
                    {
                        string message = "Invalid File Format";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

                    }


                }

                else
                {
                    string message = "Please Select Image To Upload ";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);


                }
            }
            catch (Exception ex)
            {
                string message = ex.StackTrace;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + message + "');", true);

            }
        }
        protected void ButtonClear_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text == "Yes")
            {
                CheckBox1.Visible = true;
                lblcheck.Visible = true;
            }
            else
            {
                CheckBox1.Visible = false;
                lblcheck.Visible = false;
            }
        }



        protected void btnAddLandDetails_Click(object sender, EventArgs e)
        {
            try
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                if (btnAddLandDetails.Text == "Add Detail")
                {
                    string date_to_be = DateTime.ParseExact(txtLandDeedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    objServiceTimelinesBEL.LAWID = ServiceReqNo.Trim();
                    objServiceTimelinesBEL.LandDeedDate = Convert.ToDateTime((date_to_be));
                    objServiceTimelinesBEL.LandArea = txtLandArea.Text;
                    objServiceTimelinesBEL.KhasraNumber = txtKhasraNo.Text.Trim();
                    objServiceTimelinesBEL.LandValue = txtValueOfLand.Text.Trim();
                    objServiceTimelinesBEL.StampDutyPaid = txtStampDutyPaid.Text.Trim();

                    if (ddlDistrict.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select District');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LAWDistrict = ddlDistrict.SelectedValue;
                    }
                    //objServiceTimelinesBEL.LAWDistrict = txtDistrict.Text.Trim();
                    objServiceTimelinesBEL.LAWTehsil = txtTehsil.Text.Trim();
                    objServiceTimelinesBEL.LAWVillage = txtVillage.Text.Trim();

                    if (ddlExistingLand.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Existing Project area land Use and required change with status of land');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ExistingLand = ddlExistingLand.SelectedItem.Text.Trim();
                    }
                    
                    if (ddlExistingLand.SelectedValue == "Other")
                    {
                        if (anyOtherExistingProject.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Existing Land Other Option');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.anyOtherExistingProject = anyOtherExistingProject.Text.Trim();
                        }
                    }
                    else
                    {
                        objServiceTimelinesBEL.anyOtherExistingProject = "";
                    }

                    if (ddlLandContiguous.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Project area land contiguous');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandContiguousStatus = ddlLandContiguous.SelectedItem.Text.Trim();
                    }

                    
                    if (ddlLandContiguous.SelectedValue == "No")
                    {
                        if (txtLandContiguous.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for Project Area Land Contigous');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.LandContiguous = txtLandContiguous.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.LandContiguous = "";
                    }

                    if (ddlGramGov.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Involvement of any gram sabha/ government land');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.GramGovStatus = ddlGramGov.SelectedItem.Text.Trim();
                    }

                    
                    if (ddlGramGov.SelectedValue == "Yes")
                    {
                        if (txtGramGov.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for involvement of any gram sabha/ government land');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.GramGov = txtGramGov.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.GramGov = "";
                    }

                    if (ddlLandExchange.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Requirement of Land Exchange');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandExchangeStatus = ddlLandExchange.SelectedItem.Text.Trim();
                    }
                    
                    if (ddlLandExchange.SelectedValue == "Yes")
                    {
                        if (txtLandExchange.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for Requirement of Land Exchange');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.LandExchange = txtLandExchange.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.LandExchange = "";
                    }

                    objServiceTimelinesBEL.PIPOtherDetails = txtPIPOtherDetails.Text.Trim();

                    int retVal = objServiceTimelinesBLL.AddPIPLandDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string msg = "Record added successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        ClearLandDetails();
                        BindLandDetails();
                        return;
                    }
                    else
                    {
                        string msg = "Details couldn't be saved";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
                    }
                }

                if (btnAddLandDetails.Text == "Update Detail")
                {

                    string date_to_be = DateTime.ParseExact(txtLandDeedDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    objServiceTimelinesBEL.LAWLandID = lblRecordID.Text.Trim();
                    objServiceTimelinesBEL.LandDeedDate = Convert.ToDateTime((date_to_be));
                    objServiceTimelinesBEL.LandArea = txtLandArea.Text;
                    objServiceTimelinesBEL.KhasraNumber = txtKhasraNo.Text.Trim();
                    objServiceTimelinesBEL.LandValue = txtValueOfLand.Text.Trim();
                    objServiceTimelinesBEL.StampDutyPaid = txtStampDutyPaid.Text.Trim();

                    if (ddlDistrict.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select District');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LAWDistrict = ddlDistrict.SelectedValue;
                    }
                    //objServiceTimelinesBEL.LAWDistrict = txtDistrict.Text.Trim();
                    objServiceTimelinesBEL.LAWTehsil = txtTehsil.Text.Trim();
                    objServiceTimelinesBEL.LAWVillage = txtVillage.Text.Trim();

                    if (ddlExistingLand.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Existing Project area land Use and required change with status of land');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.ExistingLand = ddlExistingLand.SelectedItem.Text.Trim();
                    }

                    if (ddlExistingLand.SelectedValue == "Other")
                    {
                        if (anyOtherExistingProject.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Existing Land Other Option');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.anyOtherExistingProject = anyOtherExistingProject.Text.Trim();
                        }
                    }
                    else
                    {
                        objServiceTimelinesBEL.anyOtherExistingProject = "";
                    }

                    if (ddlLandContiguous.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Project area land contiguous');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandContiguousStatus = ddlLandContiguous.SelectedItem.Text.Trim();
                    }


                    if (ddlLandContiguous.SelectedValue == "No")
                    {
                        if (txtLandContiguous.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for Project Area Land Contigous');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.LandContiguous = txtLandContiguous.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.LandContiguous = "";
                    }

                    if (ddlGramGov.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Involvement of any gram sabha/ government land');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.GramGovStatus = ddlGramGov.SelectedItem.Text.Trim();
                    }


                    if (ddlGramGov.SelectedValue == "Yes")
                    {
                        if (txtGramGov.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for involvement of any gram sabha/ government land');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.GramGov = txtGramGov.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.GramGov = "";
                    }

                    if (ddlLandExchange.SelectedValue == "--Select--")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select Requirement of Land Exchange');", true);
                        return;
                    }
                    else
                    {
                        objServiceTimelinesBEL.LandExchangeStatus = ddlLandExchange.SelectedItem.Text.Trim();
                    }

                    if (ddlLandExchange.SelectedValue == "Yes")
                    {
                        if (txtLandExchange.Text.Trim() == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please Enter Reason for Requirement of Land Exchange');", true);
                            return;
                        }
                        else
                        {
                            objServiceTimelinesBEL.LandExchange = txtLandExchange.Text.Trim();
                        }
                    }

                    else
                    {
                        objServiceTimelinesBEL.LandExchange = "";
                    }

                    objServiceTimelinesBEL.PIPOtherDetails = txtPIPOtherDetails.Text.Trim();

                    int retVal = objServiceTimelinesBLL.UpdatePIPLandDetails(objServiceTimelinesBEL);
                    if (retVal > 0)
                    {
                        string msg = "Record Updated successfully";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        ClearLandDetails();
                        BindLandDetails();
                        return;
                    }
                    else
                    {
                        string msg = "details couldn't be Updated";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                        return;
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
        protected void btnClearLandDetails_Click(object sender, EventArgs e)
        {
            ClearLandDetails();
        }

        protected void btnDocConfirm_Click(object sender, EventArgs e)
        {
            if (Conform_CheckBox_multiview_1.Checked == false)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                return;
            }
            else
            {
                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();


                SqlCommand cmd = new SqlCommand("[ValidatePIPDetailsAndDocuments] '" + ServiceReqNo.Trim() + "'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string ApplicantName = dt.Rows[0][0].ToString();
                    string ApplicantImg = dt.Rows[0][1].ToString();
                    string ApplicantSign = dt.Rows[0][2].ToString();
                    string Project = dt.Rows[0][4].ToString();
                    int LandDetails = Convert.ToInt32(dt.Rows[0][5].ToString());
                    int DocCount = Convert.ToInt32(dt.Rows[0][3].ToString());


                    if (Conform_CheckBox_multiview_1.Checked == false)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please certify your record before final submission.');", true);
                        return;
                    }
                    if (DocCount < 11)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please upload all your documents.');", true);
                        //Allotment.ActiveViewIndex = 4;
                        return;
                    }
                    else
                    {


                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                        try { con.Open(); } catch { }
                        SqlCommand command = con.CreateCommand();
                        command.Connection = con;
                        command.CommandText = ("update ServiceRequests set isDocAccept = '1' WHERE ServiceRequestNO ='" + ServiceReqNo + "'");
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Conform_CheckBox_multiview_1.Checked = true;
                            CheckAcceptValue();

                            string msg = "Terms and Conditions Accepted Successfully.";
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                            return;
                        }



                    }
                }
                
            }

        }

        private void ClearLandDetails()
        {
            txtLandDeedDate.Text = "";
            txtValueOfLand.Text = "";
            txtKhasraNo.Text = "";
            txtLandArea.Text = "";
            txtStampDutyPaid.Text = "";
            //txtDistrict.Text = "";
            txtTehsil.Text = "";
            txtVillage.Text = "";
            btnAddLandDetails.Text = "Add Detail";

            if (ddlDistrict.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please select District');", true);
                return;
            }
            else
            {
                objServiceTimelinesBEL.LAWDistrict = ddlDistrict.SelectedValue;
            }

            ddlExistingLand.SelectedValue = null;
            ddlLandContiguous.SelectedValue = null;
            ddlGramGov.SelectedValue = null;
            ddlLandExchange.SelectedValue = null;

            txtLandContiguous.Text = "";
            txtGramGov.Text = "";
            txtLandExchange.Text = "";


        }
        private void BindLandDetails()
        {
            try
            {

                belBookDetails objServiceTimelinesBEL = new belBookDetails();
                BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();

                objServiceTimelinesBEL.ServiceRequestNO = ServiceReqNo.Trim();
                DataSet ds = new DataSet();
                try
                {
                    ds = objServiceTimelinesBLL.GetPIPLandDetails(objServiceTimelinesBEL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Grid_LandDetails.DataSource = ds;
                        Grid_LandDetails.DataBind();
                    }
                    else
                    {
                        Grid_LandDetails.DataSource = null;
                        Grid_LandDetails.DataBind();
                    }
                    this.RegisterPostBackControl();
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
        protected void drpSPV_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCompanytypeddl(drpSPV.SelectedValue.Trim());
        }
        public class aadharcard
        {
            static int[,] d = new int[,]

        {
  {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
  {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
  {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
  {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
  {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
  {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
  {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
  {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
  {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
  {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
        };
            static int[,] p = new int[,]
             {
       {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
       {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
       {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
       {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
       {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
       {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
       {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
       {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
             };

            static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

            public static bool validateVerhoeff(string num)
            {
                int c = 0; int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[(i % 8), myArray[i]]];
                }
                return c == 0;

            }
            private static int[] StringToReversedIntArray(string num)
            {
                int[] myArray = new int[num.Length];
                for (int i = 0; i < num.Length; i++)
                {
                    myArray[i] = int.Parse(num.Substring(i, 1));
                }
                Array.Reverse(myArray); return myArray;
            }
        }

        private void CheckNMSWPFeePaid()
        {

            fetchNMdetails();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select * from tbl_NMSWPTransactionDetails where ControlID='" + ControlID.Trim() + "' and UnitID='" + UnitID.Trim() + "' and ServiceID='" + ServiceID.Trim() + "' and RequestID='" + RequestID + "' and isnull(Fee_Status,'') in ('Pending')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, RequestID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "11")
                {
                    int retVal11 = objServiceTimelinesBLL.SaveTransactionDetailsNMSWPPIPCom(objServiceTimelinesBEL);
                    if (retVal11 > 0)
                    {
                        lblPaystatus.Text = "Payment Completed";
                    }

                    string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                    string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                    string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                    string Dt = gm.UpdateNMSWPFeePaidPIP(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                    int retVal2 = 0;
                    objServiceTimelinesBEL.KYCID = ServiceReqNo;
                    retVal2 = objServiceTimelinesBLL.FormFinalSubmissionPIP(objServiceTimelinesBEL);
                    if (retVal2 >= 0)
                    {
                        string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo));
                        niveshmitrastatusupdate();
                    }
                }
                
            }
        }


        private void CheckNMSWPFeePaidPay()
        {

            fetchNMdetails();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select * from tbl_NMSWPTransactionDetails where ControlID='" + ControlID.Trim() + "' and UnitID='" + UnitID.Trim() + "' and ServiceID='" + ServiceID.Trim() + "' and RequestID='" + RequestID + "' and isnull(Fee_Status,'') in ('Paid')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, RequestID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                string Transaction_ID = data.Rows[0]["Transaction_ID"].ToString();

                if (Transaction_ID == "")
                {
                    if (StatusCode == "11")
                    {
                        string TransactionDate = dt.Rows[0]["Transaction_Date"].ToString();
                        string TransactionDateTime = dt.Rows[0]["Transaction_DateTime"].ToString();
                        string TransactionID = dt.Rows[0]["Transaction_ID"].ToString();
                        string Dt = gm.UpdateNMSWPFeePaidPIP(TransactionID, TransactionDate, TransactionDateTime, ServiceReqNo);

                        /*
                        int retVal2 = 0;
                        objServiceTimelinesBEL.KYCID = ServiceReqNo;
                        retVal2 = objServiceTimelinesBLL.FormFinalSubmissionPIP(objServiceTimelinesBEL);
                        if (retVal2 >= 0)
                        {
                            string ID = HttpUtility.UrlEncode(Encrypt(ServiceReqNo));
                            niveshmitrastatusupdate();
                        }
                        */
                    }
                }
               }
        }


        private void CheckAcceptValue()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceRequests WHERE isDocAccept = '1' and ServiceRequestNO ='" + ServiceReqNo + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Conform_CheckBox_multiview_1.Checked = true;
                Conform_CheckBox_multiview_1.Enabled = false;
                btnDocConfirm.Enabled = false;
                GridView2.Enabled = false;
                lblmsgDoc.Visible = true;

            }
            else
            {
                Conform_CheckBox_multiview_1.Checked = false;
                Conform_CheckBox_multiview_1.Enabled = true;
                btnDocConfirm.Enabled = true;
                GridView2.Enabled = true;
                lblmsgDoc.Visible = false;
            }

        }



        private void CheckNMSWPFeePaid123()
        {

            fetchNMdetails();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select * from tbl_NMSWPTransactionDetails where ControlID='" + ControlID.Trim() + "' and UnitID='" + UnitID.Trim() + "' and ServiceID='" + ServiceID.Trim() + "' and RequestID='" + RequestID + "' and isnull(Fee_Status,'') in ('Paid')", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            if (data.Rows.Count > 0)
            {
                
                DataTable dt = gm.GetNMSWP_Details(ControlID, UnitID, ServiceID, RequestID);
                string StatusCode = dt.Rows[0]["Status_Code"].ToString();

                if (StatusCode == "05")
                {
                    btn_final.Visible = false;
                }
            }
        }

    }
}