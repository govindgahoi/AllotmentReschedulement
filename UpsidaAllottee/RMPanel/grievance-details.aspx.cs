using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_Allotment;
using BLL_Allotment;

namespace UpsidaAllottee.RMPanel
{
    public partial class grievance_details : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection();
        string mapfile = "" , currentstatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 
                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {
                    

                    if (!IsPostBack)
                    {
                        //DdlRegOfficeBind();
                        GetGridData();
                        bindRegionalOffice_RM();
                        //Session["UserName"]
                        GetGridRemarks();
                    }

                    try
                    {
                        string GrievRef_Id = (Request.QueryString["Grievance_Ref_ID"]);
                        if (GrievRef_Id != "")
                        {
                            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                            SqlConnection con = new SqlConnection(constring);
                            SqlCommand cmd = new SqlCommand("select * from UPSIDA_GRS where Grievance_Ref_ID = '" + GrievRef_Id + "'", con);
                            cmd.Parameters.AddWithValue("@GrievRef_Id", GrievRef_Id);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (dt.Rows.Count > 0)
                            {
                                string Status = dt.Rows[0]["CurrentStatus"].ToString();
                                if (level == "Admin1" && Status == "Pending AT Head Office")
                                {
                                    LevelPermission.Visible = true;
                                    forwardHO.Visible = false;
                                }
                                
                                else

                                /*{
                                    LevelPermission.Visible = false;
                                }
                                */
                                if (level == "RM" && Status == "Pending AT RM")
                                {
                                    LevelPermission.Visible = true;
                                }
                                else
                                {
                                    LevelPermission.Visible = false;
                                }
                            }
                            else
                            {
                                LevelPermission.Visible = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("" + ex.Message.ToString());
                    }
                }
                else
                {
                    Response.Redirect("RMLogin.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GetGridData()
        {
            try
            {
                string GrievRef_Id = (Request.QueryString["Grievance_Ref_ID"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("select * from UPSIDA_GRS where Grievance_Ref_ID = @GrievRef_Id ", con);
                cmd.Parameters.AddWithValue("@GrievRef_Id", GrievRef_Id);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    grdAllotteeDetails.DataSource = dt;
                    grdAllotteeDetails.DataBind();

                    
                }
                else
                {
                    this.grdAllotteeDetails.DataSource = null;
                    grdAllotteeDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }

        protected void GetGridRemarks()
        {
            try
            {
                string GrievRef_Id = (Request.QueryString["Grievance_Ref_ID"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("select * from ADMIN_GRS_DETAIL where GrievanceRef_ID = @GrievRef_Id ", con);
                cmd.Parameters.AddWithValue("@GrievRef_Id", GrievRef_Id);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    GridRemarks.DataSource = dt;
                    GridRemarks.DataBind();


                }
                else
                {
                    this.GridRemarks.DataSource = null;
                    GridRemarks.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }
        private void bindRegionalOffice_RM()
        {
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand();
            ////if (level == "RM")
            ////{
            ////    cmd = new SqlCommand("usp_Regional_Office_RM", con);
            ////    cmd.CommandType = CommandType.StoredProcedure;
            ////    cmd.Parameters.AddWithValue("@userID", userName);
            ////}
            ////else
            ////{
            //    cmd = new SqlCommand("usp_Regional_Office", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            ////}
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //ddlRegOffice.DataSource = dt;
            //ddlRegOffice.DataTextField = "RegionalOffice";
            //ddlRegOffice.DataValueField = "RegionalOffice";
            //ddlRegOffice.DataBind();
            //ddlRegOffice.Items.Insert(0, new ListItem("--Select--", "01"));

            ////System.Web.UI.WebControls.ListItem liRegional = new System.Web.UI.WebControls.ListItem("--Select--", "-1");
            ////dlRO.Items.Insert(-1, "--Select--");

        }

        protected void radioForward_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioForward.Checked == true)
            //{
            //    dvPassport.Visible = true;
            //}
            //else
            //    dvPassport.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (radioForward.Checked != true && radioResolve.Checked != true)
            {
                Response.Write("<script>alert('Please Check Grievance Action')</script>");
            }
            else {
                if (radioResolve.Checked == true)
                {
                    InsertGreSystem();
                    GetGridData();
                }
                else if (radioForward.Checked == true)
                {
                    InsertGreSystem();
                    GetGridData();
                }
                //else if (radioForward.Checked == true && ddlRegOffice.SelectedValue == "01")
                //{
                //    Response.Write("<script>alert('Please select Forward to Regional Office')</script>");
                //}
                //else if (radioForward.Checked == true && ddlRegOffice.SelectedValue != "0")
                //{
                //    InsertGreSystem();
                //    GetGridData();
                //}
            }
        }
       
        protected void InsertGreSystem()
        {
            //UploadFile();
            //if (ddlGrevType.SelectedIndex == 3)
            //{
            //    Remark = txtremark.Text.Trim();
            //}
            //else
            //{
            //    Remark = "-";
            //}
            try
            {

                int maxFileSize = 20;
                if (FileUploadReport.HasFile)
                {
                    // Read the file and convert it to Byte Array
                    string filePath = FileUploadReport.PostedFile.FileName;
                    //Response.Write("<script>alert('No Plots Found. Please change search criteria!')</script>");
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = FileUploadReport.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 20 mb');", true);
                        return;
                    }

                    bool fileExist = File.Exists(filePath);
                    if (fileExist == true)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Uploaded Report with same folder/file name already exists');", true);
                        return;
                    }
                    //bool exist = Directory.EnumerateFiles(Server.MapPath("UploadedReports"), filename).Any();

                    //----BY SUNIL -----//
                    string host = Request.Url.Host.ToLower();
                    string urlValue;
                    if (host == "eservices.onlineupsidc.com") { urlValue = "C:/inetpub/vhosts/onlineupsida.com/httpdocs/Admin-Dashboard/UploadedReports/"; }
                    else if (host == "services.stagingupsida.com") { urlValue = "C:/inetpub/vhosts/stagingupsida.com/services.stagingupsida.com/UploadedReports/"; }
                    else if (host == "bank.onlineupsidc") { urlValue = "C:/inetpub/vhosts/onlineupsida.com/httpdocs/Admin-Dashboard/UploadedReports/"; }
                    else { urlValue = "C:/Users/upsidc/Desktop/Sunil-Work/UploadedReports/"; }


                    if (Directory.Exists(urlValue + (Request.QueryString["Grievance_Ref_ID"])))
                    {

                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Grievance_Ref_ID"]));

                    }
                    else
                    {
                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Grievance_Ref_ID"]));
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
                        case ".docx":
                            contenttype = "application/docx";
                            break;
                        case ".DOCX":
                            contenttype = "application/docx";
                            break;
                        case ".doc":
                            contenttype = "application/doc";
                            break;
                        case ".DOC":
                            contenttype = "application/doc";
                            break;
                    }


                    if (contenttype != String.Empty && (ext == ".pdf" || ext == ".doc" || ext == ".docx"))
                    {
                        StringBuilder sb = new StringBuilder();

                        if (FileUploadReport.HasFile)
                        {
                            try
                            {
                                sb.AppendFormat(" Uploading file: {0}", FileUploadReport.FileName);
                                mapfile = urlValue + (Request.QueryString["Grievance_Ref_ID"]) + "/" + FileUploadReport.FileName;
                                //saving the file
                                FileUploadReport.SaveAs(mapfile);



                                //Showing the file information
                                sb.AppendFormat("<br/> Save As: {0}", FileUploadReport.PostedFile.FileName);
                                sb.AppendFormat("<br/> File type: {0}", FileUploadReport.PostedFile.ContentType);
                                sb.AppendFormat("<br/> File length: {0}", FileUploadReport.PostedFile.ContentLength);
                                sb.AppendFormat("<br/> File name: {0}", FileUploadReport.PostedFile.FileName);

                            }
                            catch (Exception ex)
                            {
                                sb.Append("<br/> Error <br/>");
                                sb.AppendFormat("Unable to save file <br/> {0}", ex.Message);
                            }
                        }
                        else
                        {
                            lblUploadMsg.Text = sb.ToString();
                        }

                        lblUploadMsg.Text = "File uploaded Successfully";
                        lblUploadMsg.ForeColor = System.Drawing.Color.Green;
                        //System.Console.WriteLine("File Name "+ FileUploadReport.PostedFile.FileName);

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        lblUploadMsg.Visible = true;
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                    lblUploadMsg.Visible = true;
                    return;
                }
                

                string action = string.Empty;
                if (radioForward.Checked == true)
                {
                    currentstatus = "Pending AT Head Office";
                    action = "Forward To Head Office " ;
                }
                if (radioResolve.Checked == true)
                {
                    action = "Resolved";
                    currentstatus = "Resolved";
                }

                string GrievRef_Id = (Request.QueryString["Grievance_Ref_ID"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("USP_ADMIN_GRS_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RM_ID", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@GrievanceRef_ID", GrievRef_Id);
                cmd.Parameters.AddWithValue("@Report_Doc", mapfile);
                cmd.Parameters.AddWithValue("@Remark", txtRemarks.InnerText);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@CurrentStatus", currentstatus);
                cmd.Parameters.AddWithValue("@Uploaded_By", Session["Level"].ToString());
                cmd.Parameters.AddWithValue("@CreateDateTime", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@UploadDateTime", DateTime.Now.ToShortDateString());

                con.Open();
                int k = cmd.ExecuteNonQuery();
                //string message = (string)cmd.Parameters["@GrievanceRef_ID"].Value;
                //string msg = "Your Grievance Id is ";
                //string msg2 = " Please save Grievance Reference-Id for future reference";
                if (k != 0)
                {
                    if (radioResolve.Checked == true)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirectRes();", true);
                        return;
                        //Response.Write("<script>alert('Grievance Resolved Successfully!');</script>");
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirectHO();", true);
                        return;
                        //Response.Write("<script>alert('Grievance forwarded to Head Office!');</script>");
                    }

                }
                else
                {
                    Response.Write("<script>echo('Somthing went wrong!');</script>");
                }
                con.Close();
                Response.Redirect("Grievance-Redressal.aspx");
                //Response.AddHeader("REFRESH", "5;URL=Grievance-Redressal.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        protected void UploadFile()                                                 //BTN UPLOAD METHOD
        {
            try
            {
                int maxFileSize = 20;
                if (FileUploadReport.HasFile)
                {
                    // Read the file and convert it to Byte Array
                    string filePath = FileUploadReport.PostedFile.FileName;
                    //Response.Write("<script>alert('No Plots Found. Please change search criteria!')</script>");
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    int fileSize = FileUploadReport.PostedFile.ContentLength;
                    if (fileSize > (maxFileSize * 1024 * 1024))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 20 mb');", true);
                        return;
                    }

                    bool fileExist = File.Exists(filePath);
                    if (fileExist == true)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Uploaded Report with same folder/file name already exists');", true);
                        return;
                    }
                    //bool exist = Directory.EnumerateFiles(Server.MapPath("UploadedReports"), filename).Any();

                    //----BY SUNIL -----//
                    string host = Request.Url.Host.ToLower();
                    string urlValue;
                    if (host == "eservices.onlineupsidc.com") { urlValue = "C:/inetpub/vhosts/onlineupsida.com/httpdocs/Admin-Dashboard/UploadedReports/"; }
                    else if (host == "services.stagingupsida.com") { urlValue = "C:/inetpub/vhosts/stagingupsida.com/services.stagingupsida.com/UploadedReports/"; }
                    else if (host == "bank.onlineupsidc") { urlValue = "C:/inetpub/vhosts/onlineupsida.com/httpdocs/Admin-Dashboard/UploadedReports/"; }
                    else { urlValue = "C:/Users/upsidc/Desktop/Sunil-Work/UploadedReports/"; }


                    if (Directory.Exists(urlValue + (Request.QueryString["Grievance_Ref_ID"])))
                    {

                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Grievance_Ref_ID"]));

                    }
                    else
                    {
                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Grievance_Ref_ID"]));
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
                        case ".docx":
                            contenttype = "application/docx";
                            break;
                        case ".DOCX":
                            contenttype = "application/docx";
                            break;
                    }


                    if (contenttype != String.Empty && ext == ".pdf")
                    {
                        StringBuilder sb = new StringBuilder();

                        if (FileUploadReport.HasFile)
                        {
                            try
                            {
                                sb.AppendFormat(" Uploading file: {0}", FileUploadReport.FileName);
                                mapfile = urlValue + (Request.QueryString["Grievance_Ref_ID"]) + "/" + FileUploadReport.FileName;
                                //saving the file
                                FileUploadReport.SaveAs(mapfile);



                                //Showing the file information
                                sb.AppendFormat("<br/> Save As: {0}", FileUploadReport.PostedFile.FileName);
                                sb.AppendFormat("<br/> File type: {0}", FileUploadReport.PostedFile.ContentType);
                                sb.AppendFormat("<br/> File length: {0}", FileUploadReport.PostedFile.ContentLength);
                                sb.AppendFormat("<br/> File name: {0}", FileUploadReport.PostedFile.FileName);

                            }
                            catch (Exception ex)
                            {
                                sb.Append("<br/> Error <br/>");
                                sb.AppendFormat("Unable to save file <br/> {0}", ex.Message);
                            }
                        }
                        else
                        {
                            lblUploadMsg.Text = sb.ToString();
                        }

                        lblUploadMsg.Text = "File uploaded Successfully";
                        lblUploadMsg.ForeColor = System.Drawing.Color.Green;
                        //System.Console.WriteLine("File Name "+ FileUploadReport.PostedFile.FileName);

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                        lblUploadMsg.Visible = true;
                        return;
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                    lblUploadMsg.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message.ToString());
            }
        }


    }
}