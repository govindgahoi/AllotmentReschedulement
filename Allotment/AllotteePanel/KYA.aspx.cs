using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
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
using System.Linq;

namespace Allotment.AllotteePanel
{
    public partial class KYA : System.Web.UI.Page
    {
        #region "Create and Initialize objects "
        belBookDetails objServiceTimelinesBEL = new belBookDetails();
        BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
        #endregion
        SqlConnection con;
        string Usertype = "", pwd = "", dypPwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    //ClearAll();
                    //UpdateCaptchaText();
                    //GetNewAllotteeDetails();
                    RadioButtonList1.SelectedIndex = 0;
                }
            }
            else
            {
                Response.Redirect("AllotteeLogin.aspx");
            }
        }

        #region "Bind Allotment in GridViewn"
        public void GetNewAllotteeDetails()
        {
            belBookDetails objServiceTimelinesBEL = new belBookDetails();
            BooksDetails_BLL objServiceTimelinesBLL = new BooksDetails_BLL();
           // string Parameter = Session["AID"].ToString().Trim();
            string Parameter = txtAllotmentID.Text;
            DataSet dsAllottee = new DataSet();
            try
            {
                dsAllottee = objServiceTimelinesBLL.GetAllotmentNoDetail(Parameter);
                DataTable dt = dsAllottee.Tables[0];
                // DataTable dt1 = dsAllottee.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    // RegionalOffice, IAName, Sector, AllotteeName, AllotmentNo, PlotNo,EmailID, PhoneNumber
                    txtAName.Text = dt.Rows[0]["AllotteeName"].ToString();
                    txtRegional.Text = dt.Rows[0]["RegionalOffice"].ToString();
                    txtIndustrial.Text = dt.Rows[0]["IAName"].ToString();
                    txtPlot.Text = dt.Rows[0]["PlotNo"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    txtMobile.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    txtPAN.Text = dt.Rows[0]["PAN"].ToString();
                    txtAadhar.Text = dt.Rows[0]["AADHAR"].ToString();
                    txtAadhar.Text = dt.Rows[0]["GSTNo"].ToString();
                    txtAadhar.Text = dt.Rows[0]["GSTIssueDate"].ToString();
                    RadioButtonList1.SelectedValue = dt.Rows[0]["GSTStatus"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
        }

        #endregion

        protected void txtAllotmentID_TextChanged(object sender, EventArgs e)
        {
            GetNewAllotteeDetails();
        }

        protected void SavePopup(object sender, EventArgs e)
        {

            //if (Convert.ToString(Session["OTPR"]).Length == )

            string pwd = "";
            try
            {

                int maxFileSize = 1;
                string filename = "";
                try
                {                     
                    if (FileUpload1.HasFile)
                    {

                        // Read the file and convert it to Byte Array
                        string filePath = FileUpload1.PostedFile.FileName;
                        filename = Path.GetFileName(filePath);
                        string ext = Path.GetExtension(filename);
                        string contenttype = String.Empty;
                        int fileSize = FileUpload1.PostedFile.ContentLength;
                        if (fileSize > (maxFileSize * 1024 * 1024))
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('File size is too large. Max size should be less then or equal to 1 mb');", true);
                            return;
                        }
                        bool exist = Directory.EnumerateFiles(Server.MapPath("AllotteeKYA"), filename).Any();
                        if (exist == true)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('KYA application with same file name already exists');", true);
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

                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            objServiceTimelinesBEL.LAName = filename;
                            objServiceTimelinesBEL.content = contenttype;
                            objServiceTimelinesBEL.Uploadfile = bytes;

                            //Session["TracingName"] = objServiceTimelinesBEL.LAName;
                            //Session["TracingExt"] = objServiceTimelinesBEL.content;
                            Session["Tracing"] = objServiceTimelinesBEL.Uploadfile;
                            //lbluploadingMsg.Text = "File uploaded Successfully";
                            //lbluploadingMsg.ForeColor = System.Drawing.Color.Green;
                            //lbluploadingMsg.Visible = true;
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Only pdf format is allowed.');", true);
                            //lbluploadingMsg.Visible = true;
                            return;

                        }

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('Please choose file to upload');", true);
                        //lbluploadingMsg.Visible = true;
                        return;
                    }


                }
                catch (Exception ex)
                {
                    throw;
                }
                //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                //{
                //    string msg = "Kindly upload copy of office order";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                //    return;
                //}

                //if (Convert.ToString(Session["TracingName"]).Length <= 0)
                // string filePath = "~/TrackApplication/" + Convert.ToString(Session["TracingName"]);ToString("yyyy-MM-dd");
                // string date_of_gst = DateTime.ParseExact(txtGSTRegDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                //DateTime.ParseExact(txtGSTRegDate.Text.Trim()), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                string date_of_gst = txtGSTRegDate.Text.Trim();
                objServiceTimelinesBEL.AllotmentNo = txtAllotmentID.Text.Trim();
                objServiceTimelinesBEL.Allotteename = txtAName.Text.Trim();
                objServiceTimelinesBEL.RegionalOffice = txtRegional.Text.Trim();
                objServiceTimelinesBEL.IndustrialArea = txtIndustrial.Text.Trim();
                objServiceTimelinesBEL.PlotNo = txtPlot.Text.Trim();
                objServiceTimelinesBEL.Email = txtEmail.Text.Trim();
                objServiceTimelinesBEL.PhoneNumber = txtMobile.Text.Trim();
                objServiceTimelinesBEL.GSTStatus = RadioButtonList1.SelectedValue;
                objServiceTimelinesBEL.GstNo = txtGSTNO.Text.Trim();                
                objServiceTimelinesBEL.GSTDate = Convert.ToDateTime(date_of_gst);
                objServiceTimelinesBEL.PanNo = txtPAN.Text.Trim();
                objServiceTimelinesBEL.AadharNo = txtAadhar.Text.Trim();
                objServiceTimelinesBEL.KYAdoc = filename;
                objServiceTimelinesBEL.Status = 1;

                int retVal = objServiceTimelinesBLL.AllotteeKYA(objServiceTimelinesBEL);
                if (retVal > 0)
                {
                    string filePath = "AllotteeKYA/" + filename;
                    File.WriteAllBytes(Server.MapPath(filePath), Session["Tracing"] as byte[]);
                    string msg = "KYA Fill Successfully";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    Response.Redirect("DashBoard.aspx");
                    return;                   
                   
                }
                else
                {
                    string msg = "Allottee Registration couldn't be done";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "call_show", "alert('" + msg + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.StackTrace.ToString());
            }
            finally
            {
                objServiceTimelinesBEL = null;
                objServiceTimelinesBLL = null;
            }
        }    
    }
}