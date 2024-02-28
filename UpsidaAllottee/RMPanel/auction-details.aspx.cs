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
    public partial class auction_details : System.Web.UI.Page
    {
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        SqlConnection con = new SqlConnection();
        string mapfile = "", currentstatus = "";

        string UserName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string level = Convert.ToString(Session["Level"]);
                if (level == "Admin1" || level == "MD" || level == "JMD" || level == "RM")
                {

                    UserName = "Admin1";


                    if (!IsPostBack)
                    {
                        //DdlRegOfficeBind();
                        GetGridData();
                        //bindRegionalOffice_RM();
                        //Session["UserName"]
                        //GetGridRemarks();
                        bindregion1();
                    }

                    try
                    {
                        string Auction_Id = (Request.QueryString["Id"]);
                        if (Auction_Id != "")
                        {
                            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                            SqlConnection con = new SqlConnection(constring);
                            SqlCommand cmd = new SqlCommand("select (SELECT distinct trim(ltrim(RegionalOffice)) FROM IndustrialArea where RegionalOffice = EA.regionMapped) 'regionMappedVal', (SELECT DISTINCT trim(ltrim(IAName)) FROM [IndustrialArea] where Id = EA.iaMapped) 'iaMappedVal' ,(SELECT CONCAT(PlotNumber,' | ',[PlotArea] ,' SQmts.' )as plots FROM PlotMaster where PlotMasterId = EA.plotMapped) 'plotMappedVal' ,* from SBI_E_AUCTION EA where Id = '" + Auction_Id + "'", con);
                            cmd.Parameters.AddWithValue("@Auction_Id", Auction_Id);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (dt.Rows.Count > 0)
                            {
                                string isMapped = dt.Rows[0]["isMapped"].ToString();
                                string regionMapped = dt.Rows[0]["regionMappedVal"].ToString();
                                string iaMapped = dt.Rows[0]["iaMappedVal"].ToString();
                                string plotMapped = dt.Rows[0]["plotMappedVal"].ToString();

                                if (level == "Admin1")
                                {
                                    letterGenerated.Visible = false;
                                    
                                    isMapped = isMapped.Replace("&nbsp;", "");
                                    if (isMapped == "True")
                                    {
                                        regionDataMapped.Visible = true;
                                        regionData.Visible = false;
                                        letterGenerated.Visible = false;
                                        lblRegion.Text = regionMapped;
                                        lblIA.Text = iaMapped;
                                        lblPlot.Text = plotMapped;
                                    }
                                    else
                                    {
                                        regionDataMapped.Visible = false;
                                        regionData.Visible = true;
                                        letterGenerated.Visible = false;
                                    }
                                }
                                else
                                {
                                    letterGenerated.Visible = true;
                                    regionDataMapped.Visible = false;
                                    regionData.Visible = false;
                                    regionDataMapped.Visible = true;
                                    lblRegion.Text = regionMapped;
                                    lblIA.Text = iaMapped;
                                    lblPlot.Text = plotMapped;
                                }                                
                            }
                            else
                            {
                                letterGenerated.Visible = false;
                                regionDataMapped.Visible = false;
                                regionData.Visible = false;                                
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

        private void bindregion1()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);

            SqlCommand cmd = new SqlCommand("[spGetRegionalDetail] '" + UserName + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dlregion.DataSource = dt;
            dlregion.DataTextField = "a";
            dlregion.DataValueField = "b";
            dlregion.DataBind();
            dlregion.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void dlregion_SelectedIndexChanged(object sender, EventArgs e)
        {

            objServiceTimelinesBEL.RegionalOffice = (dlregion.SelectedValue.Trim());
            objServiceTimelinesBEL.UserName = UserName;
            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetregionalNameRecordsAuc(objServiceTimelinesBEL);
                IaDdl.DataSource = ds;
                IaDdl.DataTextField = "IAName";
                IaDdl.DataValueField = "Id";
                IaDdl.DataBind();
                IaDdl.Items.Insert(0, new ListItem("--Select--", "0"));


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

        protected void IaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            objServiceTimelinesBEL.IndustrialArea = (IaDdl.SelectedValue.Trim());

            DataSet ds = new DataSet();
            try
            {
                ds = objServiceTimelinesBLL.GetPlotForAucEntry(objServiceTimelinesBEL);
                drp_Plot.DataSource = ds;
                drp_Plot.DataTextField = "plots";
                drp_Plot.DataValueField = "PlotMasterId";
                drp_Plot.DataBind();
                drp_Plot.Items.Insert(0, new ListItem("--Select--", "0"));

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

        protected void GetGridData()
        {
            try
            {
                string Auction_Id = (Request.QueryString["Id"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("select (Winner_Price - Start_Price) 'Gain' , ((Winner_Price - Start_Price)/100) 'gainPercent', * from SBI_E_AUCTION where Id = @Auction_Id ", con);
                cmd.Parameters.AddWithValue("@Auction_Id", Auction_Id);
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
            try
            {                              
                string Id = (Request.QueryString["Id"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("USP_ADMIN_AUCTION_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@plotMapped", drp_Plot.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@iaMapped", IaDdl.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@regionMapped", dlregion.SelectedValue.Trim());

                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "MsgAndRedirectAuc();", true);
                        return;                    
                }
                else
                {
                    Response.Write("<script>echo('Somthing went wrong!');</script>");
                }
                con.Close();
                           
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.StackTrace.ToString());
            }
        }

        protected void btnGenerateLetter_Click(object sender, EventArgs e)
        {
            string Id = (Request.QueryString["Id"]);
            Response.Redirect("ReportGenrationEAuction.aspx?auction_id=" + Id);            
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

            /*
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


                    if (Directory.Exists(urlValue + (Request.QueryString["Id"])))
                    {

                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Id"]));

                    }
                    else
                    {
                        DirectoryInfo folder = Directory.CreateDirectory(urlValue + (Request.QueryString["Id"]));
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
                                mapfile = urlValue + (Request.QueryString["Id"]) + "/" + FileUploadReport.FileName;
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
                    action = "Forward To Head Office ";
                }
                if (radioResolve.Checked == true)
                {
                    action = "Resolved";
                    currentstatus = "Resolved";
                }

                string Auction_Id = (Request.QueryString["Id"]);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("USP_ADMIN_GRS_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RM_ID", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@GrievanceRef_ID", Auction_Id);
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
            */
        }
    }
}